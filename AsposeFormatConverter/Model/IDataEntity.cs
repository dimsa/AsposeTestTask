namespace AsposeFormatConverter.Model
{
    public interface IDataEntity
    {
        ICarEntity[] GetCars();
        ICarEntity AddCar();
        void RemoveCar(ICarEntity car);
    }
}
