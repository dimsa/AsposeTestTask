using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using AsposeFormatConverter.Common;
using AsposeFormatConverter.Model;

namespace AsposeFormatConverter.Converters
{
    public class XmlConverter : IDataConverter
    {

        class XmlFormatDescriptor : IFormatDescriptor
        {
            public string GetName()
            {
                return "Xml";
            }

            public string GetDescription()
            {
                return "Xml converter";
            }
        }

        public IFormatDescriptor GetFormatDescriptor()
        {
            return new XmlFormatDescriptor();
        }

        public IDataEntity ConvertFromStream(Stream stream)
        {
            var data = StreamHelper.StrFromStream(stream);

            var doc = XDocument.Parse(data);
            var res = XmlToDataEntity(doc);


            return res;
        }

        private IDataEntity XmlToDataEntity(XDocument doc)
        {
            var entity = new DataEntity();

            var cars = doc.Descendants("Car");

            foreach (var carFromFile in cars)
            {
                var car = entity.AddCar();

                var at = GetElement(carFromFile, "Date");
                car.SetDate(Convert.ToDateTime(at));

                at = GetElement(carFromFile, "BrandName");
                car.SetBrandName(at);

                at = GetElement(carFromFile, "Price");
                car.SetPrice(Convert.ToInt32(at));
            }            

            return entity;
        }

        private string GetElement(XElement node, string attrName)
        {
            var el = node.Element(attrName);

            if (el == null)
            {
                throw new Exception("Element not found " + attrName);
            }

            return el.Value;
        }

        public Stream ConvertToStream(IDataEntity entity)
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

            var stream = StreamHelper.StreamFromStr(builder.ToString());
            return stream;
        }

       
    }
}
