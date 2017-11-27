using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter
{
    public class FormatConverter : IFormatConverter
    {
        public IDataEntity OpenDataFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public IDataEntity CreateEmptyData()
        {
            throw new NotImplementedException();
        }

        public void SaveDataFile(IDataEntity dataEntity, string fileName, IFormatDescriptor type)
        {
            throw new NotImplementedException();
        }

        public IList<IFormatDescriptor> GetSupportedConversionFormats()
        {
            throw new NotImplementedException();
        }
    }
}
