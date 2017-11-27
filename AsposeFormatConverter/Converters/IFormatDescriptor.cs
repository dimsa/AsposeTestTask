using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeFormatConverter.Converters
{
    public interface IFormatDescriptor
    {
        string GetName();
        string GetDescription();
    }
}
