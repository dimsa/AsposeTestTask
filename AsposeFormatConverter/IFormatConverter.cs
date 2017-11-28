using System.Collections.Generic;
using System.Runtime.InteropServices;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;
using RGiesecke.DllExport;

namespace AsposeFormatConverter
{
    public interface IFormatConverter
    {
        [DllExport("OpenDataFromFile", CallingConvention = CallingConvention.Cdecl)]
        IDataEntity OpenDataFromFile(string fileName);

        [DllExport("CreateEmptyData", CallingConvention = CallingConvention.Cdecl)]
        IDataEntity CreateEmptyData();

        [DllExport("SaveDataFile", CallingConvention = CallingConvention.Cdecl)]
        void SaveDataFile(IDataEntity dataEntity, string fileName, IFormatDescriptor format);

        [DllExport("GetSupportedConversionFormats", CallingConvention = CallingConvention.Cdecl)]
        IList<IFormatDescriptor> GetSupportedConversionFormats();
    }
}
