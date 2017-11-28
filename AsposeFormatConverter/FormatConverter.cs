using System;
using System.Collections.Generic;
using System.Linq;
using AsposeFormatConverter.Converters;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter
{
    public class FormatConverter : IFormatConverter
    {
        private readonly Dictionary<IFormatDescriptor, IDataConverter> _converters = new Dictionary<IFormatDescriptor, IDataConverter>();
        private bool _initted;

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
