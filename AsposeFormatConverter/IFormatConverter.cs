using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter
{
    public interface IFormatConverter
    {        
        IDataEntity OpenDataFromFile(string fileName);
        IDataEntity CreateEmptyData();
        void SaveDataFile(IDataEntity dataEntity, string fileName, IFormatDescriptor format);
        IList<IFormatDescriptor> GetSupportedConversionFormats();
    }
}
