using System;
using AsposeFormatConverter.Model;
using NUnit.Framework;

namespace FormatConverterTests
{
    [TestFixture]
    public class CarEntityTests
    {
        [Test]
        public void DateGetterSetterCorrectTest()
        {
            var car = new CarEntity();
            var testDate = new DateTime(2017, 11, 27);
            car.SetDate(testDate);
            Assert.AreEqual(car.GetDate(), testDate);
        }

        [Test]
        public void DateGetterSetterIncorrectTest()
        {
            var car = new CarEntity();
            var testDate = new DateTime(2017, 11, 27);
            car.SetDate(new DateTime(2017, 11, 28));
            Assert.AreNotEqual(car.GetDate(), testDate);
        }

        [Test]
        public void BrandNameGetterSetterCorrectTest()
        {
            var car = new CarEntity();
            var testBrandName = "CorrectBrand";
            car.SetBrandName(testBrandName);
            Assert.AreEqual(car.GetBrandName(), testBrandName);
        }

        [Test]
        public void BrandNameGetterSetterIncorrectTest()
        {
            var car = new CarEntity();            
            var incorrectBrandName = "IncorrectBrand";
            car.SetBrandName("CorrrectBrand");
            Assert.AreNotEqual(car.GetBrandName(), incorrectBrandName);
        }

        [Test]
        public void PriceGetterSetterCorrectTest()
        {
            var car = new CarEntity();
            var testPrice = 17748;
            car.SetPrice(testPrice);
            Assert.AreEqual(car.GetPrice(), testPrice);
        }

        [Test]        
        public void CarConstructorCorrectTest()
        {
            var testDate = new DateTime(2017, 11, 27);
            var testBrandName = "CorrectBrand";
            var testPrice = 17748;

            var car = new CarEntity(testDate, testBrandName, testPrice);
            
            Assert.True(
                car.GetBrandName() == testBrandName &&
                car.GetDate() == testDate &&
                car.GetPrice() == testPrice
            );
        }

        [Test]
        public void CarConstructorIncorrectTest()
        {
            var testDate = new DateTime(2017, 11, 27);
            var testBrandName = "CorrectBrand";
            var testPrice = 17748;

            var car = new CarEntity(testDate, testBrandName, testPrice);

            Assert.True(
                car.GetBrandName() != "IncorrectBrand" &&
                car.GetDate() != new DateTime(2017, 11, 28) &&
                car.GetPrice() != 17747
            );
        }

        [Test]
        public void PriceGetterSetterIncorrectTest()
        {

            var car = new CarEntity();
            var incorrectBrandName = "IncorrectBrand";
            car.SetBrandName("CorrrectBrand");
            Assert.AreNotEqual(car.GetBrandName(), incorrectBrandName);
        }

    }
}
