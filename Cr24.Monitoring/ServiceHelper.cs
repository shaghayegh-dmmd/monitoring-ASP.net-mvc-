using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cr24.Monitoring
{
    public class ServiceHelper
    {
        public static List<ServiceStatusData> GetAllServiceStatus(int request)
        {
            return null;
        }

    }

    public class ServiceStatusData
    {
        public string Name { get; set; }
        public Double time { get; set; }
        public long Total { get; set; }
        public long Error { get; set; }
        public int Percent { get; set; }
        public bool LeadingToError { get; set; }
    }
}