using Level06.Sample.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Repository
{
    /// <summary>
    ///     Interface IMRTDataRepository
    /// </summary>
    public interface IMRTDataRepository : IDisposable
    {
        /// <summary>
        ///     Gets all MRT lines.
        /// </summary>
        /// <returns>List&lt;MRTLineModel&gt;.</returns>
        List<MRTLineModel> GetAllMRTLines();

        /// <summary>
        ///     Gets all MRT stations.
        /// </summary>
        /// <returns>List&lt;MRTStationModel&gt;.</returns>
        List<MRTStationModel> GetAllMRTStations();

        /// <summary>
        ///     Gets the MRT line.
        /// </summary>
        /// <param name="mrtLineID">The MRT line identifier.</param>
        /// <returns></returns>
        MRTLineModel GetMRTLine(string mrtLineID);

        /// <summary>
        ///     Gets the MRT station.
        /// </summary>
        /// <param name="mrtStationID">The MRT station identifier.</param>
        /// <returns></returns>
        MRTStationModel GetMRTStation(int mrtStationID);

        /// <summary>
        ///     取得捷運線/站最後更新時間(使用 ETrust).
        /// </summary>
        /// <returns>System.String.</returns>
        DateTime GetMRTUpdateTime();
    }
}