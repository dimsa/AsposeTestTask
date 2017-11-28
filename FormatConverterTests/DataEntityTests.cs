using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Model;
using NUnit.Framework;

namespace FormatConverterTests
{
    [TestFixture]
    public class DataEntityTests
    {
        [Test]
        public void AddAndGetCarsCountTest()
        {
            var len = 3;
            var cars = ArrangeCars(len);

            Assert.True(cars.Length == len);
        }

        [Test]
        public void RemoveAndGetCarsCountTest()
        {
            var len = 3;
            var entity = ArrangeDataEntity(len);
            var cars = entity.GetCars();
            entity.RemoveCar(cars[1]);
            cars = entity.GetCars();

            Assert.True(cars.Length == len - 1);
        }

        [Test]
        public void RemoveAndGetCarsRightEntityTest()
        {
            var len = 5;
            var data = ArrangeDataEntity(len);
            var cars = data.GetCars();
            data.RemoveCar(cars[1]);
            data.RemoveCar(cars[3]);

            // Get Cars after remove
            cars = data.GetCars();

            var entityIsRight =
                cars[0].GetBrandName() == "Test 0" &&
                cars[1].GetBrandName() == "Test 2" &&
                cars[2].GetBrandName() == "Test 4" &&
                cars.Length == len - 2;

            Assert.True(entityIsRight);
        }


        private ICarEntity[] ArrangeCars(int len)
        {
            var data = ArrangeDataEntity(len);
            return data.GetCars();
        }

        [Test]
        public void AddAndGetCarsRightEntityTest()
        {
            var len = 5;
            var cars = ArrangeCars(len);

            var rightEntities = 0;
            for (var i = 0; i < len; i++)
            {
                if (cars[i].GetBrandName() == ("Test " + i))
                    rightEntities++;
            }

            Assert.True(rightEntities == len);
        }

        private static DataEntity ArrangeDataEntity(int len)
        {
            var data = new DataEntity();

            for (var i = 0; i < len; i++)
            {
                var car = data.AddCar();
                car.SetBrandName("Test " + i);
            }
            return data;
        }
      
    }
}
