using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Repository.Models
{
    public class MRTLineModel
    {
        public string MRTLineID { get; set; }

        public string MRTLineName { get; set; }

        public string MRTLineShortName { get; set; }

        public string Area { get; set; }

        public int EnableFlag { get; set; }

        public int Sort { get; set; }
    }
}