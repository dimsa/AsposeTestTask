using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeFormatConverter.Model
{
    public class DataEntity : IDataEntity
    {
        private readonly List<ICarEntity> _cars = new List<ICarEntity>();
        public ICarEntity[] GetCars()
        {
            return _cars.ToArray();
        }

        public ICarEntity AddCar()
        {
            var car = new CarEntity();
            _cars.Add(car);
            return car;
        }

        public void RemoveCar(ICarEntity car)
        {
            _cars.Remove(car);
        }
    }
}
