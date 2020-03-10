using Level06.Sample.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service
{
    /// <summary>
    ///     Interface IMRTDataService
    /// </summary>
    public interface IMRTDataService
    {
        /// <summary>
        ///     取得所有捷運線資料.
        /// </summary>
        /// <returns>List&lt;MRTLineDto&gt;.</returns>
        List<MRTLineDto> GetAllMRTLines();

        /// <summary>
        ///     取得全部捷運站資料.
        /// </summary>
        /// <returns>List&lt;MRTStationDto&gt;.</returns>
        List<MRTStationDto> GetAllMRStations();

        /// <summary>
        ///     取得捷運線/站最後更新時間(使用 ETrust).
        /// </summary>
        /// <returns>System.String.</returns>
        string GetMRTUpdateTime();
    }
}