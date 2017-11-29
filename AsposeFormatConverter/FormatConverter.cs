using System;
using System.Collections.Generic;
using System.Linq;
using AsposeFormatConverter.Common;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter
{
    public class FormatConverter : IFormatConverter
    {
        private readonly Dictionary<IFormatDescriptor, IDataConverter> _converters = new Dictionary<IFormatDescriptor, IDataConverter>();
        private bool _initted;      

        /*
         * Trying to read file with any of registered converters
         */
        public IDataEntity OpenDataFromFile(string fileName)
        {
            var ms = StreamHelper.StreamFromFile(fileName);

            if (ms == null)
                return null;

            foreach (var converter in _converters.Values)
            {
                try
                {
                    var entity = converter.ConvertFromStream(ms);
                    if (entity != null)
                        return entity;
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return null;
        }

        public IDataEntity CreateEmptyData()
        {
            return new DataEntity();
        }

        public void SaveDataFile(IDataEntity dataEntity, string fileName, IFormatDescriptor type)
        {       
            var stream = _converters[type].ConvertToStream(dataEntity);
            StreamHelper.StreamToFile(fileName, stream);
        }

        public IFormatDescriptor[] GetSupportedConversionFormats()
        {
            return _converters.Keys.ToArray();
        }

        /*
         * Get all data converters that implements IDataConverter to simplify adding of new converters
         */
        public void Init()
        {
            if (_initted)
                return;

            var type = typeof(IDataConverter);
            var typeList = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));            

            foreach (var converter in typeList)
            {
                try
                {
                    AddInstanceOf(converter);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);         
                }                
            }           
            
            _initted = true;
        }

        private void AddInstanceOf(Type converter)
        {
            var ci = converter.GetConstructor(new Type[] { });

            if (ci != null)
            {
                var obj = ci.Invoke(new object[] { });
                var con = (IDataConverter) obj;
                _converters.Add(con.GetFormatDescriptor(), con);
            }
        }

        public FormatConverter()
        {
            Init();
        }
    }
}
