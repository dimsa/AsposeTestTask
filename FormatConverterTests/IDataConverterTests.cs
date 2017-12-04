using System;
using System.Runtime.InteropServices;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;
using NUnit.Framework;

namespace FormatConverterTests
{
    [TestFixture(typeof(BinConverter), "Bin", "Bin converter")]
    [TestFixture(typeof(XmlConverter), "Xml", "Xml converter")]
    public class DataConverterTests<TConverter> where TConverter : IDataConverter, new()
    {
        private IDataConverter _converter;
        private IDataEntity _dataStub;
        private string _desc;
        private string _name;


        public DataConverterTests(string name, string desc)
        {
            _converter = new TConverter();
            _name = name;
            _desc = desc;
            _dataStub = CreateDataStub();
        }
      
        private DataEntity CreateDataStub()
        {
            var dataStub = new DataEntity();
            var len = 5;
            for (int i = 0; i < len; i++)
            {
                var car = dataStub.AddCar();
                car.SetDate(DateByIterator(i));
                car.SetBrandName(BrandByIterator(i));
                car.SetPrice(PriceByIterator(i));
            }

            return dataStub;
        }

        private int PriceByIterator(int i)
        {
            return 100 + i * 1000;
        }

        private string BrandByIterator(int i)
        {
            return "Brand " + i;
        }

        private DateTime DateByIterator(int i)
        {
            return new DateTime(2017, 12, i + 1);
        }

        [Test]
        public void TestFormatDescriptorName()
        {
            var fd = _converter.GetFormatDescriptor();

            Assert.AreEqual(fd.GetName(), _name);
        }

        [Test]
        public void TestFormatDescriptorDescriptor()
        {
            var fd = _converter.GetFormatDescriptor();

            Assert.AreEqual(fd.GetDescription(), _desc);
        }

        [Test]
        public void TestConvertToStreamAndBack()
        {
            var stream = _converter.ConvertToStream(_dataStub);
            var testFromStream = _converter.ConvertFromStream(stream);

            var testCars = _dataStub.GetCars();
            var cars = testFromStream.GetCars();

            // Here we can use more than one assert because there no matter why collecation are different
            Assert.True(testCars.Length == cars.Length);
 
            for (var i = 0; i < cars.Length; i++)
            {
                var car = cars[i];
                var testCar = testCars[i];
                Assert.AreEqual(car.GetBrandName(), testCar.GetBrandName());
                Assert.AreEqual(car.GetBrandName(), BrandByIterator(i));
                Assert.AreEqual(car.GetDate(), testCar.GetDate());
                Assert.AreEqual(car.GetDate(), DateByIterator(i));
                Assert.AreEqual(car.GetPrice(), testCar.GetPrice());
                Assert.AreEqual(car.GetPrice(), PriceByIterator(i));
            }

        }

    }
}

