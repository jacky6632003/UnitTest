using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service.DTOs
{
    public class SchoolInfoDto
    {
        /// <summary>
        /// 學校ID.
        /// </summary>
        /// <value>The school identifier.</value>
        public string SchoolID { get; set; }

        /// <summary>
        /// 學校類別 1:國小;2:國中;3:高中職;4:大專院校.
        /// </summary>
        /// <value>The school type identifier.</value>
        public int SchoolTypeID { get; set; }

        /// <summary>
        /// 學校名稱.
        /// </summary>
        /// <value>The name of the school.</value>
        public string SchoolName { get; set; }

        /// <summary>
        /// 學校資料更新時間.
        /// </summary>
        /// <value>The update time.</value>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 房屋物件數.
        /// </summary>
        /// <value>The house count.</value>
        public int HouseCount { get; set; }

        /// <summary>
        /// 社區數.
        /// </summary>
        /// <value>The building count.</value>
        public int BuildingCount { get; set; }

        /// <summary>
        /// 縣市ID.
        /// </summary>
        /// <value>The county identifier.</value>
        public string CountyID { get; set; }

        /// <summary>
        /// 鄉鎮市區ID.
        /// </summary>
        /// <value>The district identifier.</value>
        public int? DistrictID { get; set; }

        /// <summary>
        /// Longitude (POI.TGx).
        /// </summary>
        /// <value>The longitude.</value>
        public double? Longitude { get; set; }

        /// <summary>
        /// Latitude (POI.TGY).
        /// </summary>
        /// <value>The latitude.</value>
        public double? Latitude { get; set; }
    }
}