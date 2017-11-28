using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    public class BinConverter : IDataConverter
    {
        public IFormatDescriptor GetFormatDescriptor()
        {
            throw new NotImplementedException();
        }

        public IDataEntity ConvertFrom(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Stream ConvertTo(IDataEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
