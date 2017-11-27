using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
