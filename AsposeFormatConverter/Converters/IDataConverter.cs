using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    interface IDataConverter
    {
        IFormatDescriptor GetFormatDescriptor();
        IDataEntity ConvertFrom(IStream stream);
        IStream ConvertTo(IDataEntity entity);
    }
}
