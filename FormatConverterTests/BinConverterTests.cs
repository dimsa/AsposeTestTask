using System.IO;
using System.Text;
using AsposeFormatConverter.Converters;
using NUnit.Framework;

namespace FormatConverterTests
{
    [TestFixture]
    public class BinConverterTests
    {
        struct CarEntityWithoutConstraits
        {
            public int Day { get; set; }
            public int Month { get; set; }
            public int Year { get; set; }
            public int Price { get; set; }
            public string BrandName { get; set; }
        }

        private Stream MakeTestStream(CarEntityWithoutConstraits[] cars, int overrideCount = -1)
        {
            var stream = new MemoryStream();
            using (var sw = new BinaryWriter(stream, Encoding.Unicode, true))
            {
                WriteHeader(sw);
                WriteTestCars(cars, sw, overrideCount);
            }

            return stream;
        }

        private void WriteTestCars(CarEntityWithoutConstraits[] cars, BinaryWriter sw, int overrideCount = -1)
        {
            var count = overrideCount == -1 ? cars.Length : overrideCount;

            sw.Write(BinFormatterHelper.IntToBytes(count));
            for (var i = 0; i < count; i++)
            {
                var car = cars[i];
                WriteBinDate(car.Day, car.Month, car.Year, sw);
                WriteBinBrand(car.BrandName, sw);
                WriteBinPrice(car.Price, sw);
            }
        }

        private void WriteHeader(BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.CharToBytes((char) 0x2526));
        }

        private void WriteBinDate(int d, int m, int y, BinaryWriter sw)
        {
            var day = d.ToString();
            var month = m.ToString();
            var year = y.ToString();

            var dateStr = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year.PadLeft(4);
            var bytes = BinFormatterHelper.StringOfIntToAsciiByte(dateStr);
            sw.Write(bytes);
        }

        private void WriteBinBrand(string brand, BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.IntToBytes(brand.Length));
            sw.Write(BinFormatterHelper.StrToBytes(brand));
        }

        private void WriteBinPrice(int price, BinaryWriter sw)
        {
            sw.Write(BinFormatterHelper.IntToBytes(price));
        }

        [TestCase(-12, 4, 2017, 200, "Brand")]
        [TestCase(12, -4, 2017, 200, "Brand")]
        [TestCase(12, 4, -3, 200, "Brand")]
        [TestCase(31, 11, 2017, 200, "Brand")]
        public void CarDateInvalidTest(int d, int m, int y, int price, string brandName)
        {
            var cars = new[]
            {
                new CarEntityWithoutConstraits()
                {
                    BrandName = "TestBrand",
                    Price = 200,
                    Day = 2,
                    Month = 2,
                    Year = 2017
                },
                new CarEntityWithoutConstraits()
                {
                    BrandName = brandName,
                    Price = price,
                    Day = d,
                    Month = m,
                    Year = y
                },
            };

            var stream = MakeTestStream(cars);
            var converter = new BinConverter();

            Assert.That(() => converter.ConvertFromStream(stream), Throws.Exception.With.Message.EqualTo("Date is incorrect"));
        }

        [TestCase(1, 1, 2017, 200, "Brand")]
        [TestCase(1, -1, 2017, 200, "Brand")]
        public void CarCountInvalidTest(int d, int m, int y, int price, string brandName)
        {
            var cars = new[]
            {
                new CarEntityWithoutConstraits()
                {
                    BrandName = "TestBrand",
                    Price = 200,
                    Day = 2,
                    Month = 2,
                    Year = 2017
                },
                new CarEntityWithoutConstraits()
                {
                    BrandName = brandName,
                    Price = price,
                    Day = d,
                    Month = m,
                    Year = y
                },
            };

            var stream = MakeTestStream(cars, -2);
            var converter = new BinConverter();

            Assert.That(() => converter.ConvertFromStream(stream), Throws.Exception.With.Message.EqualTo("Car count can not be lesser than 0. File Incorrect."));
        }
    }
}
