using System;
using System.Linq;
using AsposeFormatConverter;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;

namespace AsposeTestTask
{
    class Program
    {
        private static FormatConverter _converter;
        private static IFormatDescriptor[] _availableFormats;

        /// <summary>
        /// Example of using AsposeFormatConverter
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _converter = new FormatConverter();
            _availableFormats = _converter.GetSupportedConversionFormats();
                        
            // Create file names
            var xmlFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Test.xml";
            var binFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Test.bin";

            var xmlConvertFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "ConvertTest.xml";
            var binConvertFileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "ConvertTest.bin";

            // Create Demo Files
            CreateNewXml(xmlFileName);
            CreateNewBin(binFileName);

            // Convert Demo
            var dataEntity = OpenAnyFormat(xmlFileName);
            ConvertEntityTo(dataEntity, binConvertFileName, _availableFormats.FirstOrDefault(it => it.GetName() == "Bin"));

            dataEntity = OpenAnyFormat(binFileName);
            ConvertEntityTo(dataEntity, xmlConvertFileName, _availableFormats.FirstOrDefault(it => it.GetName() == "Xml"));
           
            WriteReport(xmlFileName, binFileName, binConvertFileName, xmlConvertFileName);
            Console.ReadKey();
        }

        private static void WriteReport(string xmlFileName, string binFileName, string binConvertFileName,
            string xmlConvertFileName)
        {
            Console.WriteLine("Files created and converted:");
            Console.WriteLine(@"  CreatedXml {0}", xmlFileName);
            Console.WriteLine(@"  CreatedBin {0}", binFileName);
            Console.WriteLine(@"  ConvertedXmlToBin {0}", binConvertFileName);
            Console.WriteLine(@"  ConvertedBinToXml {0}", xmlConvertFileName);
        }

        private static void ConvertEntityTo(IDataEntity dataEntity, string fileName, IFormatDescriptor format)
        {
            _converter.SaveDataFile(dataEntity, fileName, format);
        }

        private static IDataEntity OpenAnyFormat(string fileName)
        {
            return _converter.OpenDataFromFile(fileName);
        }        

        private static void CreateNewBin(string binFileName)
        {
            var data = _converter.CreateEmptyData();

            var car = data.AddCar();
            car.SetBrandName("BinCar1");
            car.SetPrice(1500);
            car.SetDate(new DateTime(2015, 11, 1));

            car = data.AddCar();
            car.SetBrandName("BinCar2");
            car.SetPrice(2200);
            car.SetDate(new DateTime(2014, 11, 10));

            _converter.SaveDataFile(
                data,
                binFileName,
                _availableFormats.FirstOrDefault(it => it.GetName() == "Bin"));

        }

        private static void CreateNewXml(string xmlFileName)
        {
            var data = _converter.CreateEmptyData();

            var car = data.AddCar();
            car.SetBrandName("XmlCar1");
            car.SetPrice(500);
            car.SetDate(new DateTime(2017, 12, 1));

            car = data.AddCar();
            car.SetBrandName("XmlCar2");
            car.SetPrice(1200);
            car.SetDate(new DateTime(2016, 12, 1));

            _converter.SaveDataFile(
                data, 
                xmlFileName, 
                _availableFormats.FirstOrDefault(it=> it.GetName() == "Xml"));

        }
    }
}
