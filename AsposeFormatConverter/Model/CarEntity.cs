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
            _price = price;
        }
    }
}
