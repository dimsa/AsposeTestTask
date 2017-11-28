using System;
using System.IO;
using System.Text;

namespace AsposeFormatConverter.Common
{
    public class StreamHelper
    {
        public static string StrFromStream(Stream stream)
        {
            if (stream == null)
                return "";

            stream.Seek(0, SeekOrigin.Begin);            
            using (var sr = new StreamReader(stream))
            {
                return sr.ReadToEnd();
            }
        }

        public static Stream StreamFromStr(string data)
        {
            if (string.IsNullOrEmpty(data))
                return new MemoryStream();            

            var stream = new MemoryStream();
            using (var sw = new StreamWriter(stream, Encoding.Unicode))
            {
                sw.WriteLine(data);
            }
            return stream;
        }

        public static Stream StreamFromFile(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    return ms;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool StreamToFile(string fileName, Stream stream)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fs);                                        
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
