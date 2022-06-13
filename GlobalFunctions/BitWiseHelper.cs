using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
  public static class BitWiseHelper
  {
    /// <summary>
    /// Check bit is on
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Bit"></param>
    /// <returns></returns>
    public static bool IsOn(byte Value, byte Bit)
    { return (Value >> Bit & 1) == 1; }

    public static bool IsOn(ushort Value, byte Bit)
    { return (Value >> Bit & 1) == 1; }

    public static bool IsOn(uint Value, byte Bit)
    { return (Value >> Bit & 1) == 1; }

    public static bool IsOnUint64(UInt64 Value, int Bit)
    { return (Value >> Bit & 1) == 1; }

    /// <summary>
    /// Set a bit
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Bit"></param>
    /// <param name="On"></param>
    /// <returns></returns>
    public static int Set(int Value, byte Bit, bool On)
    { return On ? Value | (1 << Bit) : Clear(Value, Bit); }

    public static UInt16 Set(UInt16 Value, byte Bit, bool On)
    { return (UInt16)(On ? Value | (1 << Bit) : Clear(Value, Bit)); }

    public static uint Set(uint Value, byte Bit, bool On)
    { return (uint)(On ? Value | (1 << Bit) : Clear(Value, Bit)); }

    /// <summary>
    /// Clear Bit
    /// </summary>
    /// <param name="Value"></param>
    /// <param name="Bit"></param>
    /// <returns></returns>
    public static uint Clear(uint Value, byte Bit)
    { return (uint)(Value & ~(1 << Bit)); }

    public static int Clear(int Value, byte Bit)
    { return Value & ~(1 << Bit); }

    public static UInt16 Clear(UInt16 Value, byte Bit)
    { return (UInt16)(Value & ~(1 << Bit)); }

    public static bool[] ToBoolArray(short number)
    {
      bool[] array = new bool[16];
      for (int i = 0; i < 16; i++)
      {
        array[i] = ((number >> i) & 0x01) != 0;
      }
      return array;
    }

    public static bool[] ToBoolArray(byte number)
    {
      bool[] array = new bool[8];
      for (int i = 0; i < 8; i++)
      {
        array[i] = ((number >> i) & 0x01) != 0;
      }
      return array;
    }

    /// <summary>
    /// Convert bool array to byte string
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static string ToHexString(bool[] array)
    {
      byte num = 0;
      for (int i = 0; i < 8; i++)
        num += array[i] ? (byte)Math.Pow(2, i) : (byte)0;
      string temp = "00" + String.Format("{0:X}", (byte)num);
      return temp.Substring(temp.Length - 2, 2);
    }

    

  }
}
