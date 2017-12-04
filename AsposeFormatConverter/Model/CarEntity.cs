using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeFormatConverter.Model
{
    public class CarEntity : ICarEntity
    {
        private DateTime _date;
        private string _brandName;
        private int _price;

        public CarEntity(DateTime date, string brandName, int price)
        {
            SetDate(date);
            SetBrandName(brandName);
            SetPrice(price);
        }

        public CarEntity()
        {
            
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public void SetDate(DateTime date)
        {
            _date = date;
        }

        public string GetBrandName()
        {
            return _brandName;
        }

        public void SetBrandName(string brandName)
        {
            _brandName = brandName;
        }

        public int GetPrice()
        {
            return _price;
        }

        public void SetPrice(int price)
        {
            if (price < 0)
                throw new ArgumentException("Price must be positive or 0");
            _price = price;
        }
    }
}
