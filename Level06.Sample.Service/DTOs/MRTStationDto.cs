using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service.DTOs
{
    public class MRTStationDto
    {
        /// <summary>
        /// 排序.
        /// </summary>
        /// <value>The sort.</value>
        public string Sort { get; set; }

        /// <summary>
        /// ID.
        /// </summary>
        /// <value>The identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// 捷運線代碼.
        /// </summary>
        /// <value>The MRT line.</value>
        public string MRTLine { get; set; }

        /// <summary>
        /// 捷運站名稱.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// 縣市.
        /// </summary>
        /// <value>The county.</value>
        public string County { get; set; }

        /// <summary>
        /// 鄉鎮市區.
        /// </summary>
        /// <value>The district.</value>
        public string District { get; set; }

        /// <summary>
        /// GoogleMap - Latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double? Latitude { get; set; }

        /// <summary>
        /// GoogleMap - Longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double? Longitude { get; set; }

        /// <summary>
        /// POI流水號, 參照[POI].[dbo].[TrendGo_POILevel].TGsn.
        /// </summary>
        /// <value>The tg sn.</value>
        public int? TGSn { get; set; }
    }
}