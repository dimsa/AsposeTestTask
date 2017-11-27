using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    class BinConverter : IDataConverter
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
            throw new NotImplementedException();
        }
    }
}
