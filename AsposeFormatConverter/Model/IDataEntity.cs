using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeFormatConverter.Model
{
    public interface IDataEntity
    {
        ICarEntity[] GetCars();
        ICarEntity AddCar();
        void RemoveCar(ICarEntity car);
    }
}
