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

        public IDataEntity ConvertFromStream(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Stream ConvertToStream(IDataEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
