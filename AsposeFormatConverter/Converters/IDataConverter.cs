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
    public interface IDataConverter
    {
        IFormatDescriptor GetFormatDescriptor();
        IDataEntity ConvertFrom(Stream stream);
        Stream ConvertTo(IDataEntity entity);
    }
}
