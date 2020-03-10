using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Repository.Models
{
    public class MRTStationModel
    {
        public int MRTStationID { get; set; }

        public string MRTStationName { get; set; }

        public string MRTLine { get; set; }

        public byte EnableFlag { get; set; }

        public string Sort { get; set; }

        public string County { get; set; }

        public string District { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public int? TGSn { get; set; }
    }
}