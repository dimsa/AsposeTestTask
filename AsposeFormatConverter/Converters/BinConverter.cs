using System;
using System.IO;
using System.Text;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    public class BinConverter : IDataConverter
    {
        class BinFormatDescriptor : IFormatDescriptor
        {
            public string GetName()
            {
                return "Bin";
            }

            public string GetDescription()
            {
                return "Bin converter";
            }
        }

        const char CHeader = (char)0x2526;

        public IFormatDescriptor GetFormatDescriptor()
        {
            return new BinFormatDescriptor();
        }

        public IDataEntity ConvertFromStream(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var res = new DataEntity();

            using (var sw = new BinaryReader(stream, Encoding.Unicode, true))
            {
                ReadAndCheckHeader(sw);         
                ReadCars(res, sw);
            }

            return res;
        }

        private void ReadCars(DataEntity data, BinaryReader sr)
        {
            var carsCount = BitConverter.ToInt32(sr.ReadBytes(4), 0);

            for (var i = 0; i < carsCount; i++)
            {
                var car = data.AddCar();
                ReadCar(car, sr);               
            }
        }

        private void ReadCar(ICarEntity car, BinaryReader sr)
        {
            car.SetDate(ReadDate(sr));
            car.SetBrandName(ReadBrandName(sr));
            car.SetPrice(ReadPrice(sr));
        }

        private int ReadPrice(BinaryReader sw)
        {
            return sw.ReadInt32();
        }

        private string ReadBrandName(BinaryReader sw)
        {
            var brandNameSize = sw.ReadInt32();
            var brandName = BinFormatterHelper.ReadStr(sw.ReadBytes(brandNameSize * 2));

            return brandName;
        }

        private DateTime ReadDate(BinaryReader sw)
        {
            var dateStr = BinFormatterHelper.AsciiByteToStringOfInt(sw.ReadBytes(8));

            var day = Convert.ToInt32(dateStr.Substring(0,2));
            var month = Convert.ToInt32(dateStr.Substring(2, 2));
            var year = Convert.ToInt32(dateStr.Substring(4, 4));

            return new DateTime(year, month, day);
        }

        private void ReadAndCheckHeader(BinaryReader sw)
        {
            try
            {
                var bytes = sw.ReadBytes(2);
                var header = BitConverter.ToChar(bytes, 0);
                if (header != CHeader)
                    throw new Exception("Not supported bin type");
            }
            catch (Exception)
            {
                throw new Exception("Can not read file");
            }
        }

        public Stream ConvertToStream(IDataEntity entity)
        {
            var stream = new MemoryStream();
            var cars = entity.GetCars();

            using (var sw = new BinaryWriter(stream, Encoding.Unicode, true))
            {
                WriteHeader(sw);
                WriteCars(cars, sw);
            }

            return stream;
        }

        private void WriteCars(ICarEntity[] cars, BinaryWriter sw)
        {
           sw.Write(BinFormatterHelper.IntToBytes(cars.Length));
           for (var i = 0; i < cars.Length; i++)
           {
                WriteCar(cars[i], sw);
           }
        }

        private void WriteHeader(BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.CharToBytes((char)0x2526));
        }

        private void WriteCar(ICarEntity car, BinaryWriter sw)
        {
            WriteDate(car.GetDate(), sw);
            WriteBrand(car.GetBrandName(), sw);
            WritePrice(car.GetPrice(), sw);
        }

        private void WritePrice(int price, BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.IntToBytes(price));
        }

        private void WriteBrand(string brand, BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.IntToBytes(brand.Length));
            sw.Write(BinFormatterHelper.StrToBytes(brand));
        }

        private static void WriteDate(DateTime date, BinaryWriter sw)
        {
            var day = date.Day.ToString();
            var month = date.Month.ToString();
            var year = date.Year.ToString();

            var dateStr = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year.PadLeft(4);
            var bytes = BinFormatterHelper.StringOfIntToAsciiByte(dateStr);
            sw.Write(bytes);
        }      
    }
}
