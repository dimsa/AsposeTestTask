﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    class XmlConverter : IDataConverter
    {
        public IFormatDescriptor GetFormatDescriptor()
        {
            throw new NotImplementedException();
        }

        public IDataEntity ConvertFrom(IStream stream)
        {
            throw new NotImplementedException();
        }

        public IStream ConvertTo(IDataEntity entity)
        {            
        /*    var cars = entity.GetCars();

            foreach (var car in cars)
            {
                
            }*/
            return null;


        }
    }
}
