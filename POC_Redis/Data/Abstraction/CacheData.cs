using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Redis.Data
{
    public class CacheData
    {
        public string key { get; set; }

        public string value { get; set; }
        public string time { get; set; }
    }
}
