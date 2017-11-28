using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeFormatConverter.Common
{
    public class Exceptions
    {
        public static void ElementNotFound(string name)
        {
            throw  new Exception("Element not found " + name);
        }
    }
}
