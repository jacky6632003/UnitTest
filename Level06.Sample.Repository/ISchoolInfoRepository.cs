using Level06.Sample.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Repository
{
    /// <summary>
    /// Interface ISchoolInfoRepository
    /// </summary>
    public interface ISchoolInfoRepository : IDisposable
    {
        /// <summary>
        /// 取得所有學校資訊.
        /// </summary>
        /// <returns>List&lt;SchoolInfoModel&gt;.</returns>
        List<SchoolInfoModel> GetAllSchoolInfos();

        /// <summary>
        /// 取得學校資料最近更新時間.
        /// </summary>
        /// <returns>DateTime.</returns>
        DateTime GetSchoolUpdateTime();
    }
}