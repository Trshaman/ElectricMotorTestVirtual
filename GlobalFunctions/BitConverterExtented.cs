using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
  public static class BitConverterExtented
  {
    /// <summary>
    /// Convert byte array to int16
    /// </summary>
    /// <param name="data"></param>
    /// <param name="startIndex"></param>
    /// <param name="isLittleEndian">if false return (int16)((High)data[startIndex] + (Low)data[startIndex+1]), if true return (int16)((High)data[startIndex+1] + (Low)data[startIndex])
    /// </param>
    /// <returns></returns>
    public static Int16 ToInt16(byte[] data, int startIndex, bool isLittleEndian)
    {
      if (isLittleEndian)
        return (Int16)((data[startIndex] << 8) | data[startIndex + 1]);
      else
        return (Int16)((data[startIndex + 1] << 8) | data[startIndex]);
    }

    /// <summary>
    /// Convert byte array to int16
    /// </summary>
    /// <param name="data"></param>
    /// <param name="startIndex"></param>
    /// <param name="isLittleEndian">if false return (int16)((High)data[startIndex] + (Low)data[startIndex+1])
    /// if true return (int16)((High)data[startIndex+1] + (Low)data[startIndex])
    /// </param>
    /// <returns></returns>

    public static Int32 ToInt32(byte[] data, int startIndex, bool isLittleEndian)
    {
      if (isLittleEndian)
        return (data[startIndex] << 24)
         | (data[startIndex + 1] << 16)
         | (data[startIndex + 2] << 8)
         | data[startIndex + 3];
      else
        return (data[startIndex + 3] << 24)
          | (data[startIndex + 2] << 16)
          | (data[startIndex + 1] << 8)
          | data[startIndex];
    }

    public static UInt32 ToUInt32(byte[] data, int startIndex, bool isLittleEndian)
    {
      if (isLittleEndian)
        return (UInt32)((data[startIndex] << 24)
         | (data[startIndex + 1] << 16)
         | (data[startIndex + 2] << 8)
         | data[startIndex + 3]);
      else
        return (UInt32)((data[startIndex + 3] << 24)
          | (data[startIndex + 2] << 16)
          | (data[startIndex + 1] << 8)
          | data[startIndex]);
    }

    public static UInt16 ToUInt16(byte[] data, int startIndex, bool isLittleEndian)
    {
      if (isLittleEndian)
        return (UInt16)((data[startIndex] << 8) | data[startIndex + 1]);
      else
        return (UInt16)((data[startIndex + 1] << 8) | data[startIndex]);
    }

    public static UInt16 ToBitwiseUInt16(byte[] data, int startIndex, int length, bool isLittleEndian)
    {
      if (data.Length == 8)
      {
        if (!isLittleEndian)
          Array.Reverse(data);
        UInt64 allByte = BitConverter.ToUInt64(data, 0);
        UInt64 mask = 0;
        for (int i = 0; i < length; i++)
          mask |= ((UInt64)1 << i);
        return (UInt16)((allByte >> startIndex) & mask);
      }
      else
        return 0;
    }

    public static float ToFloat(byte[] data, int startIndex, bool isLittleEndian)
    {

      if (!isLittleEndian)
      {
        byte[] copiedArray = new byte[4];
        Array.Copy(data, startIndex, copiedArray, 0, 4);
        Array.Reverse(copiedArray);
        return BitConverter.ToSingle(copiedArray, 0);
      }
      else
        return BitConverter.ToSingle(data, startIndex);
      
    }

    public static UInt64 ToBitwiseUInt64(byte[] data, int startIndex, int length, bool isLittleEndian)
    {
      if (data.Length == 8)
      {
        if (!isLittleEndian)
          Array.Reverse(data);
        UInt64 allByte = BitConverter.ToUInt64(data, 0);
        UInt64 mask = 0;
        for (int i = 0; i < length; i++)
          mask |= ((UInt64)1 << i);
        return (UInt64)((allByte >> startIndex) & mask);
      }
      else
        return 0;
    }

    public static Int64 ToBitwiseInt64(byte[] data, int startIndex, int length, bool isLittleEndian)
    {
      if (data.Length == 8)
      {
        if (!isLittleEndian)
          Array.Reverse(data);
        UInt64 allByte = BitConverter.ToUInt64(data, 0);
        UInt64 mask = 0;
        for (int i = 0; i < length; i++)
          mask |= ((UInt64)1 << i);
        UInt64 res = ((allByte >> startIndex) & mask);
        Int64 coff = BitWiseHelper.IsOnUint64(res, length - 1) ? -1 : 1;
        return (Int64)(coff * (Int64)res);
      }
      else
        return 0;
    }

    public static void SetBitwiseUInt64(UInt64 value, int startBit, int length, ref UInt64 intValue)
    {
      UInt64 res = (value << startBit);
      intValue = intValue | res;
    }

    //public static void SetBitwiseInt64(Int64 value, int startBit, int length, ref UInt64 intValue)
    //{
    //  Int64 res = (value << startBit);

    //  intValue =(UInt64)( intValue | res);
    //}

    /// <summary>
    /// Special for ICPDAS four byte data to int32 ((MSB)byte[2] byte[3] byte[0] byte[1](LSB))
    /// </summary>
    /// <param name="data"></param>
    /// <param name="startIndex"></param>
    /// <returns></returns>
    public static Int32 ToIcpDasInt32(byte[] data, int startIndex)
    {
      return (data[startIndex + 2] << 24)
              | (data[startIndex + 3] << 16)
              | (data[startIndex] << 8)
              | data[startIndex + 1];
    }

    /// <summary>
    /// Special for ICPDAS four byte data to uint32 ((MSB)byte[2] byte[3] byte[0] byte[1](LSB))
    /// </summary>
    /// <param name="data"></param>
    /// <param name="startIndex"></param>
    /// <returns></returns>
    public static UInt32 ToIcpDasUInt32(byte[] data, int startIndex)
    {
      return (UInt32)((data[startIndex + 2] << 24)
              | (data[startIndex + 3] << 16)
              | (data[startIndex] << 8)
              | data[startIndex + 1]);
    }



    public static byte[] GetLittleEndianBytes(ushort val)
    {
      byte[] bytes = BitConverter.GetBytes(val);
      Array.Reverse(bytes);
      return bytes;
    }

    public static byte[] GetLittleEndianBytes(int val)
    {
      byte[] bytes = BitConverter.GetBytes(val);
      Array.Reverse(bytes);
      return bytes;
    }

    public static byte[] GetLittleEndianBytes(uint val)
    {
      byte[] bytes = BitConverter.GetBytes(val);
      Array.Reverse(bytes);
      return bytes;
    }

    public static byte[] GetLittleEndianBytes(short val)
    {
      byte[] bytes = BitConverter.GetBytes(val);
      Array.Reverse(bytes);
      return bytes;
    }


  }
}
