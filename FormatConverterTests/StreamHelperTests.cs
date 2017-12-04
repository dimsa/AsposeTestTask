using System;
using System.IO;
using System.Text;
using AsposeFormatConverter.Common;
using NUnit.Framework;

namespace FormatConverterTests
{
    [TestFixture]
    public class StreamHelperTests
    {
        [Datapoint]
        public string EmptyFromStream = "";

        [Datapoint]
        public string NullStrFromStream = null;

        [Datapoint]
        public string TestStringFromStream = "Hello World!";

        [Theory]
        public void StrFromStreamTest(string text)
        {
            
            var stream = ArrangeStreamFromText(text);

            if (text == null)
            {
                text = "";
            }
               
            var str = StreamHelper.StrFromStream(stream);
            Assert.AreEqual(str, text);
        }

        [Theory]
        public void StreamFromStrTest(string text)
        {
            // Ideal Stream
            var idealStream = ArrangeStreamFromText(text);

            // My Stream
            var stream = StreamHelper.StreamFromStr(text);
            stream.Seek(0, SeekOrigin.Begin);

           CheckStreamForEqual(idealStream, stream);
        }

        private  MemoryStream ArrangeStreamFromText(string text)
        {
            var idealStream = new MemoryStream();
            if (!string.IsNullOrEmpty(text))
            {
                using (var sw = new StreamWriter(idealStream, Encoding.Unicode, text.Length, true))
                {
                    sw.Write(text);
                }
            }
            idealStream.Seek(0, SeekOrigin.Begin);
            return idealStream;
        }

        private void CheckStreamForEqual(MemoryStream idealStream, Stream stream)
        {
            Assert.AreEqual(idealStream.Length, stream.Length);

            for (var i = 0; i < idealStream.Length - 1; i++)
            {
                var buf1 = new byte[1];
                stream.Read(buf1, 0, 1);
                var buf2 = new byte[1];
                idealStream.Read(buf2, 0, 1);

                Assert.AreEqual(buf1[0], buf2[0]);
            }
        }

        [Theory]
        public void StreamToFileAndViceVersa(string text)
        {
            var fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "test1.txt";
            var stream = ArrangeStreamFromText(text);
            StreamHelper.StreamToFile(fileName, stream);

            var testStream = StreamHelper.StreamFromFile(fileName);

            CheckStreamForEqual(stream, testStream);
        }
    }
}
