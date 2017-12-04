using System;
using System.Text;

namespace AsposeFormatConverter.Common
{
    public class BinFormatterHelper
    {
        public static byte[] StringOfIntToAsciiByte(string str)
        {
            var unicodeBytes = Encoding.Unicode.GetBytes(str);
            var asciiBytes = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, unicodeBytes);
            return asciiBytes;
        }

        public static string AsciiByteToStringOfInt(byte[] bytes)
        {
            var unicodeBytes = Encoding.Convert(Encoding.ASCII, Encoding.Unicode, bytes);
            return Encoding.Unicode.GetString(unicodeBytes);
        }

        public static byte[] StrToBytes(string data)
        {
            return Encoding.Unicode.GetBytes(data);
        }

        public static byte[] IntToBytes(int data)
        {
            return BitConverter.GetBytes(data);
        }

        public static byte[] CharToBytes(char data)
        {
            return BitConverter.GetBytes(data);
        }

        public static string ReadStr(byte[] data)
        {
            return Encoding.Unicode.GetString(data);
        }

    }
}