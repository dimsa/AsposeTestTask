using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using AsposeFormatConverter.Common;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    public class XmlConverter : IDataConverter
    {
        public IFormatDescriptor GetFormatDescriptor()
        {
            throw new NotImplementedException();
        }

        public IDataEntity ConvertFrom(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            string data;
            using (var sr = new StreamReader(stream))
            {
                data = sr.ReadToEnd();               
            }

            var doc = XDocument.Parse(data);
            var res = XmlToDataEntity(doc);

            return res;
        }

        private IDataEntity XmlToDataEntity(XDocument doc)
        {
            var entity = new DataEntity();

            foreach (var carFromFile in doc.Descendants("Document"))
            {
                var car = entity.AddCar();

                var at = GetAttribute(carFromFile, "Date");
                car.SetDate(Convert.ToDateTime(at));

                at = GetAttribute(carFromFile, "BrandName");
                car.SetBrandName(at);

                at = GetAttribute(carFromFile, "Price");
                car.SetPrice(Convert.ToInt32(at));
            }            

            return entity;
        }

        private string GetAttribute(XElement node, string attrName)
        {
            var el = node.Attribute(attrName);

            if (el == null)
            {
                Exceptions.ElementNotFound(attrName);
                return "";
            }

            return el.Value;
        }

        public Stream ConvertTo(IDataEntity entity)
        {   
            var builder = new StringBuilder();
            builder.AppendLine(@"<?xml version=""1.0"" encoding=""UTF32Encoding-8""?>");
            builder.AppendLine(@"<Document>");

            var cars = entity.GetCars();
            foreach (var car in cars)
            {
                builder.AppendLine(@"  <Car>");
                builder.AppendFormat(@"    <Date>{0}</Date>", car.GetDate());
                builder.AppendLine();
                builder.AppendFormat(@"    <BrandName>{0}</BrandName>", car.GetBrandName());
                builder.AppendLine();
                builder.AppendFormat(@"    <Price>{0}</Price>", car.GetPrice());
                builder.AppendLine(@"  </Car>");                             
            }

            builder.AppendLine(@"</Document>");

            var stream = SaveStrToStream(builder);
            return stream;
        }

        private MemoryStream SaveStrToStream(StringBuilder builder)
        {
            var stream = new MemoryStream();
            using (var sw = new StreamWriter(stream, Encoding.Unicode))
            {
                sw.WriteLine(builder.ToString());
            }
            return stream;
        }
    }
}
