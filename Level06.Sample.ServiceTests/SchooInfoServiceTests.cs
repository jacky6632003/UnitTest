using Microsoft.VisualStudio.TestTools.UnitTesting;
using Level06.Sample.Service;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.Linq;
using Level06.Sample.Repository.Models;
using System.IO;
using NSubstitute;
using AutoMapper;
using CsvHelper;
using Level06.Sample.Repository;
using Level06.Sample.Service.Mappings;
using System.Globalization;

namespace Level06.Sample.Service.Tests
{
    [TestClass]
    [DeploymentItem(@"TestData\SchoolInfoModels.csv")]
    public class SchooInfoServiceTests
    {
        private IMapper _mapper
        {
            get
            {
                var config = new MapperConfiguration(options => { options.AddProfile<MappingProfile>(); });
                return config.CreateMapper();
            }
        }

        private ISchoolInfoRepository _schoolInfoRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._schoolInfoRepository = Substitute.For<ISchoolInfoRepository>();
        }

        private SchooInfoService GetSystemUnderTest()
        {
            var sut = new SchooInfoService(this._mapper, this._schoolInfoRepository);
            return sut;
        }

        /// <summary>
        /// Gets the school information data source from CSV.
        /// </summary>
        /// <returns>List&lt;SchoolInfoModel&gt;.</returns>
        private List<SchoolInfoModel> GetSchoolInfoDataSourceFromCsv()
        {
            // arrange
            var schoolInfoModels = new List<SchoolInfoModel>();
            using (var sr = new StreamReader(@"SchoolInfoModels.csv"))
            using (var reader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = reader.GetRecords<SchoolInfoModel>();
                schoolInfoModels.AddRange(records);
            }

            return schoolInfoModels;
        }

        //-----------------------------------------------------------------------------------------

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolUpdateTimeTest")]
        public void GetSchoolUpdateTimeTest()
        {
            // arrange
            var updateTime = new DateTime(2014, 5, 14, 9, 52, 19);
            this._schoolInfoRepository.GetSchoolUpdateTime().Returns(updateTime);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetSchoolUpdateTime();

            // assert
            actual.Should().NotBeNull();
            actual.Should().Be("2014-05-14 09:52:19");
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetAllSchoolInfos")]
        //[DeploymentItem(@"TestData\SchoolInfoModels.csv")]
        public void GetAllSchoolInfos_取得所有資料()
        {
            // arrange
            var dataSource = this.GetSchoolInfoDataSourceFromCsv();
            this._schoolInfoRepository.GetAllSchoolInfos().Returns(dataSource);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetAllSchoolInfos();

            // assert
            actual.Should().NotBeNull();
            actual.Count.Should().Be(dataSource.Count);
        }

        //-----------------------------------------------------------------------------------------

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_County_沒有輸入CountyId_應拋出ArgumentNullException()
        {
            // arrange
            var sut = this.GetSystemUnderTest();
            var countyId = "";

            // act
            Action action = () => sut.GetSchoolInfosByCondition(countyId);

            // assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_County_輸入CountyId_0001_取出該縣市的所有學校資料()
        {
            // arrange
            var countyId = "0001";

            var schoolInfoModels = this.GetSchoolInfoDataSourceFromCsv();

            this._schoolInfoRepository.GetAllSchoolInfos().Returns(schoolInfoModels);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetSchoolInfosByCondition(countyId);

            // assert
            actual.Should().NotBeNull();
            actual.All(x => x.CountyID == countyId).Should().BeTrue();
        }

        //-----------------------------------------------------------------------------------------

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_County_沒有輸入CountyId_有輸入districtId_應拋出ArgumentNullException()
        {
            // arrange
            var sut = this.GetSystemUnderTest();
            var countyId = "";
            var districtId = "36";

            // act
            Action action = () => sut.GetSchoolInfosByCondition(countyId, districtId);

            // assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_County_有輸入CountyId_沒有輸入districtId_應拋出ArgumentNullException()
        {
            // arrange
            var sut = this.GetSystemUnderTest();
            var countyId = "0001";
            var districtId = "";

            // act
            Action action = () => sut.GetSchoolInfosByCondition(countyId, districtId);

            // assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        //[DeploymentItem(@"TestData\SchoolInfoModels.csv")]
        public void GetSchoolInfosByCondition_County_CountyId輸入0001_DistrictId輸入36_取出該縣市區域的所有學校資料()
        {
            // arrange
            var countyId = "0001";
            var districtId = "36";

            var dataSource = this.GetSchoolInfoDataSourceFromCsv();
            this._schoolInfoRepository.GetAllSchoolInfos().Returns(dataSource);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetSchoolInfosByCondition(countyId, districtId);

            // assert
            actual.Should().NotBeNull();
            actual.All
                  (
                      x => x.CountyID == countyId
                           &&
                           x.DistrictID.Value == Convert.ToInt32(districtId)
                  )
                  .Should().BeTrue();
        }

        //-----------------------------------------------------------------------------------------

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_沒有輸入CountyId_應拋出ArgumentNullException()
        {
            // arrange
            var sut = this.GetSystemUnderTest();
            var countyId = "";
            var districtId = "36";
            var schoolType = SchoolTypeEnum.ElementarySchool;

            // act
            Action action = () => sut.GetSchoolInfosByCondition(countyId, districtId, schoolType);

            // assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        public void GetSchoolInfosByCondition_沒有輸入DistrictId_應拋出ArgumentNullException()
        {
            // arrange
            var sut = this.GetSystemUnderTest();
            var countyId = "0001";
            var districtId = "";
            var schoolType = SchoolTypeEnum.ElementarySchool;

            // act
            Action action = () => sut.GetSchoolInfosByCondition(countyId, districtId, schoolType);

            // assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [Owner("Kevin")]
        [TestCategory("SchooInfoService")]
        [TestProperty("SchooInfoService", "GetSchoolInfosByCondition")]
        //[DeploymentItem(@"TestData\SchoolInfoModels.csv")]
        public void GetSchoolInfosByCondition_輸入CountyID_輸入DistrictId_輸入SchoolType_取得符合條件的學校資料()
        {
            // arrange
            var countyId = "0001";
            var districtId = "36";
            var schoolType = SchoolTypeEnum.ElementarySchool;

            var dataSource = GetSchoolInfoDataSourceFromCsv();
            this._schoolInfoRepository.GetAllSchoolInfos().Returns(dataSource);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetSchoolInfosByCondition(countyId, districtId, schoolType);

            // assert
            actual.Should().NotBeNull();
            actual.All
                  (
                      x => x.CountyID == countyId
                           && x.DistrictID.Value == Convert.ToInt32(districtId)
                           && x.SchoolTypeID == Convert.ToInt32(schoolType)
                  )
                  .Should().BeTrue();
        }
    }
}