using Level06.Sample.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service
{
    /// <summary>
    /// Interface ISchooInfoService
    /// </summary>
    public interface ISchooInfoService
    {
        /// <summary>
        /// 取得學校資料最近的更新時間.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetSchoolUpdateTime();

        /// <summary>
        /// 取得所有學校資訊.
        /// </summary>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        List<SchoolInfoDto> GetAllSchoolInfos();

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId);

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <param name="districtId">鄉鎮市區ID.</param>
        /// <param name="?">The ?.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId, string districtId);

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <param name="districtId">鄉鎮市區ID.</param>
        /// <param name="schoolType">學校類別.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId, string districtId, SchoolTypeEnum schoolType);
    }
}