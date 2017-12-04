using System.IO;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    public interface IDataConverter
    {
        IFormatDescriptor GetFormatDescriptor();
        IDataEntity ConvertFromStream(Stream stream);
        Stream ConvertToStream(IDataEntity entity);
    }
}
