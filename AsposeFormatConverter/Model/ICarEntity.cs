using System;

namespace AsposeFormatConverter.Model
{
    public interface ICarEntity
    {
        DateTime GetDate();
        void SetDate(DateTime date);

        string GetBrandName();
        void SetBrandName(string brandName);

        int GetPrice();
        void SetPrice(int price);
    }
}
