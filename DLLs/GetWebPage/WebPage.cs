// Decompiled with JetBrains decompiler
// Type: GetWebPage.WebPage
// Assembly: GetWebPage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4731ED81-7DD6-43A4-BCD0-48683AB2CD0D
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\GetWebPage.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.MobileControls;

#nullable disable
namespace GetWebPage;

public class WebPage
{
  private Uri m_uri;
  private List<Link> m_links;
  private string m_title;
  private string m_html;
  private string m_outstr;
  private bool m_good;
  private int m_pagesize;
  private static Dictionary<string, CookieContainer> webcookies = new Dictionary<string, CookieContainer>();
  private string FirmwareVersion;

  public string URL => this.m_uri.AbsoluteUri;

  public string Firmware
  {
    get
    {
      if (this.FirmwareVersion == "")
      {
        Match match = new Regex("<td>Q500 v(\\s|\\S)*?</td>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(this.m_html);
        if (match.Success)
          this.FirmwareVersion = match.Groups[0].Value.Trim();
      }
      return this.FirmwareVersion;
    }
  }

  public string Title
  {
    get
    {
      if (this.m_title == "")
      {
        Match match = new Regex("(?m)<title[^>]*>(?<title>(?:\\w|\\W)*?)</title[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(this.m_html);
        if (match.Success)
          this.m_title = match.Groups["title"].Value.Trim();
      }
      return this.m_title;
    }
  }

  public string M_html
  {
    get
    {
      if (this.m_html == null)
        this.m_html = "";
      return this.m_html;
    }
  }

  public List<Link> Links
  {
    get
    {
      if (this.m_links.Count == 0)
        this.getLinks();
      return this.m_links;
    }
  }

  public string Context
  {
    get
    {
      if (this.m_outstr == "")
        this.getContext((int) short.MaxValue);
      return this.m_outstr;
    }
  }

  public int PageSize => this.m_pagesize;

  public List<Link> InsiteLinks
  {
    get => this.getSpecialLinksByUrl("^http://" + this.m_uri.Host, (int) short.MaxValue);
  }

  public bool IsGood => this.m_good;

  public string Host => this.m_uri.Host;

  private List<Link> getLinks()
  {
    if (this.m_links.Count == 0)
    {
      Regex[] regexArray = new Regex[2]
      {
        new Regex("<a\\shref\\s*=\"(?<URL>[^\"]*).*?>(?<title>[^<]*)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline),
        new Regex("<[i]*frame[^><]+src=(\"|')?(?<url>([^>\"'\\s)])+)(\"|')?[^>]*>", RegexOptions.IgnoreCase)
      };
      for (int index = 0; index < 2; ++index)
      {
        for (Match match = regexArray[index].Match(this.m_html); match.Success; match = match.NextMatch())
        {
          try
          {
            string str1 = HttpUtility.UrlDecode(new Uri(this.m_uri, match.Groups["URL"].Value).AbsoluteUri);
            string str2 = "";
            if (index == 0)
              str2 = new Regex("(<[^>]+>)|(\\s)|( )|&|\"", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(match.Groups["text"].Value, "");
            Link link = new Link();
            link.Text = str2;
            link.NavigateUrl = str1;
            this.m_links.Add(link);
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }
    return this.m_links;
  }

  private string getFirstNchar(string instr, int firstN, bool withLink)
  {
    if (this.m_outstr == "")
    {
      this.m_outstr = instr.Clone() as string;
      this.m_outstr = new Regex("(?m)<script[^>]*>(\\w|\\W)*?</script[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, "");
      this.m_outstr = new Regex("(?m)<style[^>]*>(\\w|\\W)*?</style[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, "");
      this.m_outstr = new Regex("(?m)<select[^>]*>(\\w|\\W)*?</select[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, "");
      if (!withLink)
        this.m_outstr = new Regex("(?m)<a[^>]*>(\\w|\\W)*?</a[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, "");
      this.m_outstr = new Regex("(<[^>]+?>)| ", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, "");
      this.m_outstr = new Regex("(\\s)+", RegexOptions.IgnoreCase | RegexOptions.Multiline).Replace(this.m_outstr, " ");
    }
    return this.m_outstr.Length <= firstN ? this.m_outstr : this.m_outstr.Substring(0, firstN);
  }

  public string getContext(int firstN) => this.getFirstNchar(this.m_html, firstN, true);

  public List<Link> getSpecialLinksByUrl(string pattern, int count)
  {
    if (this.m_links.Count == 0)
      this.getLinks();
    List<Link> specialLinksByUrl = new List<Link>();
    List<Link>.Enumerator enumerator = this.m_links.GetEnumerator();
    int num = 0;
    while (enumerator.MoveNext() && num < count)
    {
      if (new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(enumerator.Current.NavigateUrl).Success)
      {
        specialLinksByUrl.Add(enumerator.Current);
        ++num;
      }
    }
    return specialLinksByUrl;
  }

  public List<Link> getSpecialLinksByText(string pattern, int count)
  {
    if (this.m_links.Count == 0)
      this.getLinks();
    List<Link> specialLinksByText = new List<Link>();
    List<Link>.Enumerator enumerator = this.m_links.GetEnumerator();
    int num = 0;
    while (enumerator.MoveNext() && num < count)
    {
      if (new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(enumerator.Current.Text).Success)
      {
        specialLinksByText.Add(enumerator.Current);
        ++num;
      }
    }
    return specialLinksByText;
  }

  public string getSpecialWords(string pattern)
  {
    if (this.m_outstr == "")
      this.getContext((int) short.MaxValue);
    Match match = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline).Match(this.m_outstr);
    return match.Success ? match.Value : string.Empty;
  }

  private void Init(string _url)
  {
    try
    {
      this.m_uri = new Uri(_url);
      this.m_links = new List<Link>();
      this.m_html = "";
      this.m_outstr = "";
      this.m_title = "";
      this.m_good = true;
      if (_url.EndsWith(".rar") || _url.EndsWith(".dat") || _url.EndsWith(".msi"))
      {
        this.m_good = false;
      }
      else
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(this.m_uri);
        httpWebRequest.AllowAutoRedirect = true;
        httpWebRequest.MaximumAutomaticRedirections = 3;
        httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";
        httpWebRequest.KeepAlive = true;
        httpWebRequest.Timeout = 10000;
        lock (WebPage.webcookies)
        {
          if (WebPage.webcookies.ContainsKey(this.m_uri.Host))
          {
            httpWebRequest.CookieContainer = WebPage.webcookies[this.m_uri.Host];
          }
          else
          {
            CookieContainer cookieContainer = new CookieContainer();
            WebPage.webcookies[this.m_uri.Host] = cookieContainer;
            httpWebRequest.CookieContainer = cookieContainer;
          }
        }
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        Stream responseStream = response.GetResponseStream();
        if (!response.ContentType.ToLower().StartsWith("text/") || response.ContentLength > 4194304L /*0x400000*/)
        {
          response.Close();
          this.m_good = false;
        }
        else
        {
          Encoding encoding1 = Encoding.Default;
          int num = response.ContentType.ToLower().IndexOf("charset=");
          if (num != -1)
          {
            Encoding encoding2;
            try
            {
              encoding2 = Encoding.GetEncoding(response.ContentType.Substring(num + "charset".Length + 1));
            }
            catch
            {
              encoding2 = Encoding.Default;
            }
            this.m_html = new StreamReader(responseStream, encoding2).ReadToEnd();
          }
          else
          {
            this.m_html = new StreamReader(responseStream, encoding1).ReadToEnd();
            string name = new Regex("charset=(?<cding>[^=]+)?\"", RegexOptions.IgnoreCase).Match(this.m_html).Groups["cding"].Value;
            Encoding encoding3;
            try
            {
              encoding3 = Encoding.GetEncoding(name);
            }
            catch
            {
              encoding3 = Encoding.Default;
            }
            byte[] bytes = Encoding.Default.GetBytes(this.m_html.ToCharArray());
            this.m_html = encoding3.GetString(bytes);
            if (this.m_html.Split('?').Length > 100)
              this.m_html = Encoding.Default.GetString(bytes);
          }
          this.m_pagesize = this.m_html.Length;
          this.m_uri = response.ResponseUri;
          response.Close();
        }
      }
    }
    catch (Exception ex)
    {
    }
  }

  public WebPage(string _url)
  {
    try
    {
      _url = Uri.UnescapeDataString(_url);
    }
    catch
    {
    }
    this.Init(_url);
  }
}
