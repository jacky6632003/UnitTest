using AutoMapper;
using Level06.Sample.Repository;
using Level06.Sample.Repository.Models;
using Level06.Sample.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Level06.Sample.Service
{
    public class SchooInfoService : ISchooInfoService
    {
        private readonly IMapper _mapper;

        private readonly ISchoolInfoRepository _schoolInfoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchooInfoService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="schoolInfoRepository">The schoolInfoRepository.</param>
        public SchooInfoService(IMapper mapper,
                                ISchoolInfoRepository schoolInfoRepository)
        {
            this._mapper = mapper;
            this._schoolInfoRepository = schoolInfoRepository;
        }

        //-----------------------------------------------------------------------------------------

        /// <summary>
        /// 取得學校資料最近的更新時間.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetSchoolUpdateTime()
        {
            var source = this._schoolInfoRepository.GetSchoolUpdateTime();
            var result = source.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// 取得所有學校資訊.
        /// </summary>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<SchoolInfoDto> GetAllSchoolInfos()
        {
            var source = this._schoolInfoRepository.GetAllSchoolInfos();

            var result = this._mapper.Map<List<SchoolInfoModel>, List<SchoolInfoDto>>(source);

            return result;
        }

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// countyid;please input value
        /// or
        /// districtId;please input value
        /// </exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId)
        {
            if (string.IsNullOrWhiteSpace(countyId))
            {
                throw new ArgumentNullException(nameof(countyId), "please input value");
            }

            var allSchoolInfos = this.GetAllSchoolInfos();
            var schools = allSchoolInfos.Where(x => x.CountyID == countyId);
            return schools.ToList();
        }

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <param name="districtId">鄉鎮市區ID.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId, string districtId)
        {
            if (string.IsNullOrWhiteSpace(countyId))
            {
                throw new ArgumentNullException(nameof(countyId), "please input value");
            }

            if (string.IsNullOrWhiteSpace(districtId))
            {
                throw new ArgumentNullException(nameof(districtId), "please input value");
            }

            var allSchoolInfos = this.GetAllSchoolInfos();

            var schools = allSchoolInfos.Where
            (
                x => x.CountyID == countyId
                     && x.DistrictID.HasValue
                     && x.DistrictID.Value == Convert.ToInt32(districtId)
            );

            return schools.ToList();
        }

        /// <summary>
        /// 取得指定條件下的學校資訊.
        /// </summary>
        /// <param name="countyId">縣市ID.</param>
        /// <param name="districtId">鄉鎮市區ID.</param>
        /// <param name="schoolType">學校類別.</param>
        /// <returns>List&lt;SchoolInfoDto&gt;.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<SchoolInfoDto> GetSchoolInfosByCondition(string countyId,
                                                             string districtId,
                                                             SchoolTypeEnum schoolType)
        {
            if (string.IsNullOrWhiteSpace(countyId))
            {
                throw new ArgumentNullException(nameof(countyId), "please input value");
            }

            if (string.IsNullOrWhiteSpace(districtId))
            {
                throw new ArgumentNullException(nameof(districtId), "please input value");
            }

            var allSchoolInfos = this.GetAllSchoolInfos();

            var schools = allSchoolInfos.Where
            (
                x => x.CountyID == countyId
                     && x.DistrictID.HasValue
                     && x.DistrictID.Value == Convert.ToInt32(districtId)
                     && x.SchoolTypeID == Convert.ToInt32(schoolType)
            );

            return schools.ToList();
        }
    }
}