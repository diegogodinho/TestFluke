using Bussines.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFukeApi
{
    public class Settings : ISettings
    {
        public string UrlBaseApi
        {
            get
            {
                return "https://eonet.sci.gsfc.nasa.gov/api/v2.1/";
            }
        }
    }
}
