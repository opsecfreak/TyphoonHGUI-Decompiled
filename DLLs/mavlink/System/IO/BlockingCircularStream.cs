// Decompiled with JetBrains decompiler
// Type: System.IO.BlockingCircularStream
// Assembly: mavlink, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 89C080C4-B46E-410C-A3FD-D5B3CAF0EF8F
// Assembly location: C:\Program Files (x86)\TyphoonHGUI\myDLL\mavlink.dll

using System.Text;
using System.Threading;

#nullable disable
namespace System.IO;

public class BlockingCircularStream : Stream
{
  private byte[] mBuffer;
  private int mWritePosition;
  private int mReadPosition;
  private int mCapacity;
  private AutoResetEvent mBlockSignal = new AutoResetEvent(false);
  private bool mReadIsAborted;
  private object mAccessLock = new object();

  public BlockingCircularStream(int bufferCapacity)
  {
    this.mCapacity = bufferCapacity;
    this.mBuffer = new byte[bufferCapacity];
  }

  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    this.AbortRead();
    this.mBlockSignal.Dispose();
  }

  public override bool CanRead => true;

  public override bool CanSeek => false;

  public override bool CanWrite => true;

  public override void Flush()
  {
  }

  public override long Length
  {
    get
    {
      lock (this.mAccessLock)
        return this.mWritePosition >= this.mReadPosition ? (long) (this.mWritePosition - this.mReadPosition) : (long) (this.mCapacity - this.mReadPosition + this.mWritePosition);
    }
  }

  public override long Position
  {
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    if (count > this.mCapacity)
      throw new IndexOutOfRangeException("Tried to read more bytes than the capacity of the circular buffer.");
    this.mReadIsAborted = false;
    while (this.Length < (long) count)
    {
      this.mBlockSignal.WaitOne();
      if (this.mReadIsAborted)
        return -1;
    }
    lock (this.mAccessLock)
    {
      if (this.mReadPosition + count <= this.mCapacity)
      {
        this.CopyBytes(this.mBuffer, buffer, this.mReadPosition, offset, count);
        this.mReadPosition += count;
      }
      else
      {
        int count1 = this.mCapacity - this.mReadPosition;
        int count2 = count - count1;
        this.CopyBytes(this.mBuffer, buffer, this.mReadPosition, offset, count1);
        this.CopyBytes(this.mBuffer, buffer, 0, offset + count1, count2);
        this.mReadPosition = count2;
      }
      return count;
    }
  }

  public void AbortRead()
  {
    this.mReadIsAborted = true;
    this.mBlockSignal.Set();
  }

  public override int ReadByte()
  {
    while (this.mReadPosition == this.mWritePosition)
      this.mBlockSignal.WaitOne();
    lock (this.mAccessLock)
    {
      if (this.mReadPosition == this.mCapacity)
        this.mReadPosition = 0;
      return (int) this.mBuffer[this.mReadPosition++];
    }
  }

  public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

  public override void SetLength(long value) => throw new NotImplementedException();

  public override void Write(byte[] buffer, int offset, int count)
  {
    if (count > this.mCapacity)
      throw new IndexOutOfRangeException("Tried to write more bytes than the capacity of the circular buffer.");
    lock (this.mAccessLock)
    {
      if (this.mWritePosition + count <= this.mCapacity)
      {
        this.CopyBytes(buffer, this.mBuffer, offset, this.mWritePosition, count);
        this.mWritePosition += count;
      }
      else
      {
        int count1 = this.mCapacity - this.mWritePosition;
        int count2 = count - count1;
        if (count2 > this.mReadPosition)
          throw new InternalBufferOverflowException("Data is being overwritten without being read. May need to increase capacity.");
        this.CopyBytes(buffer, this.mBuffer, offset, this.mWritePosition, count1);
        this.CopyBytes(buffer, this.mBuffer, offset + count1, 0, count2);
        this.mWritePosition = count2;
      }
    }
    this.mBlockSignal.Set();
  }

  public override string ToString()
  {
    return $"{Encoding.UTF8.GetString(this.mBuffer)}: r:{this.mReadPosition} w:{this.mWritePosition} l:{this.Length}";
  }

  private void CopyBytes(
    byte[] source,
    byte[] destination,
    int sourceStart,
    int destinationStart,
    int count)
  {
    for (int index = 0; index < count; ++index)
      destination[destinationStart + index] = source[sourceStart + index];
  }
}
