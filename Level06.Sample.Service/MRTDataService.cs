using AutoMapper;
using Level06.Sample.Repository;
using Level06.Sample.Repository.Models;
using Level06.Sample.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service
{
    /// <summary>
    /// class MRTDataService
    /// </summary>
    /// <seealso cref="Sample.Service.IMRTDataService" />
    public class MRTDataService : IMRTDataService
    {
        private readonly IMapper _mapper;

        private readonly IMRTDataRepository _mrtDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MRTDataService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="mrtDataRepository">The mrtDataRepository.</param>
        public MRTDataService(IMapper mapper,
                              IMRTDataRepository mrtDataRepository)
        {
            this._mapper = mapper;
            this._mrtDataRepository = mrtDataRepository;
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        ///     Gets all MRT lines.
        /// </summary>
        /// <returns>List&lt;DTOs.MRTLineDto&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<MRTLineDto> GetAllMRTLines()
        {
            var result = new List<MRTLineDto>();

            var lines = this._mrtDataRepository.GetAllMRTLines();

            result = this._mapper.Map<List<MRTLineModel>, List<MRTLineDto>>(lines);
            return result;
        }

        /// <summary>
        ///     取得全部捷運站資料.
        /// </summary>
        /// <returns>List&lt;MRTStationDto&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<MRTStationDto> GetAllMRStations()
        {
            var result = new List<MRTStationDto>();

            var stations = this._mrtDataRepository.GetAllMRTStations();

            result = this._mapper.Map<List<MRTStationModel>, List<MRTStationDto>>(stations);
            return result;
        }

        /// <summary>
        ///     取得捷運線/站最後更新時間(使用 ETrust).
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetMRTUpdateTime()
        {
            var result = this._mrtDataRepository.GetMRTUpdateTime();
            return result.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}