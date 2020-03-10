using Microsoft.VisualStudio.TestTools.UnitTesting;
using Level06.Sample.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Level06.Sample.Repository.Models;
using FluentAssertions;
using System.IO;
using CsvHelper;
using Level06.Sample.Repository;
using NSubstitute;
using AutoMapper;
using Level06.Sample.Service.Mappings;
using System.Globalization;

namespace Level06.Sample.Service.Tests
{
    [TestClass]
    [DeploymentItem(@"TestData\MRTLineModel.csv")]
    [DeploymentItem(@"TestData\MRTStationModel.csv")]
    public class MRTDataServiceTests
    {
        private IMapper _mapper
        {
            get
            {
                var config = new MapperConfiguration(options => { options.AddProfile<MappingProfile>(); });
                return config.CreateMapper();
            }
        }

        private IMRTDataRepository _mrtDataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._mrtDataRepository = Substitute.For<IMRTDataRepository>();
        }

        private MRTDataService GetSystemUnderTest()
        {
            var sut = new MRTDataService(this._mapper, this._mrtDataRepository);
            return sut;
        }

        /// <summary>
        /// Gets the MRT line data from CSV.
        /// </summary>
        /// <returns>List&lt;MRTLineModel&gt;.</returns>
        private List<MRTLineModel> GetMRTLineDataFromCsv()
        {
            // arrange
            var mrtLineModels = new List<MRTLineModel>();
            using (var sr = new StreamReader(@"MRTLineModel.csv"))
            using (var reader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = reader.GetRecords<MRTLineModel>();
                mrtLineModels.AddRange(records);
            }

            return mrtLineModels;
        }

        /// <summary>
        /// Gets the MRT station data from CSV.
        /// </summary>
        /// <returns>List&lt;MRTStationModel&gt;.</returns>
        private List<MRTStationModel> GetMRTStationDataFromCsv()
        {
            // arrange
            var mrtStationModels = new List<MRTStationModel>();
            using (var sr = new StreamReader(@"MRTStationModel.csv"))
            using (var reader = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                var records = reader.GetRecords<MRTStationModel>();
                mrtStationModels.AddRange(records);
            }

            return mrtStationModels;
        }

        //-----------------------------------------------------------------------------------------
        // GetAllMRTLines

        [TestMethod]
        [TestCategory("MRTDataService")]
        [TestProperty("MRTDataService", "GetAllMRTLines")]
        public void GetAllMRTLines_取得所有捷運線資料()
        {
            // arrange
            var dataSource = this.GetMRTLineDataFromCsv();
            this._mrtDataRepository.GetAllMRTLines().Returns(dataSource);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetAllMRTLines();

            // assert
            actual.Should().NotBeNull();
            actual.Count.Should().Be(13);
        }

        //-----------------------------------------------------------------------------------------
        // GetAllMRStations

        [TestMethod]
        [TestCategory("MRTDataService")]
        [TestProperty("MRTDataService", "GetAllMRStations")]
        public void GetAllMRStations_取得所有捷運站資料()
        {
            // arrange
            var dataSource = this.GetMRTStationDataFromCsv();
            this._mrtDataRepository.GetAllMRTStations().Returns(dataSource);

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetAllMRStations();

            // assert
            actual.Should().NotBeNull();
            actual.Count.Should().Be(237);
        }

        //-----------------------------------------------------------------------------------------
        // GetMRTUpdateTime

        [TestMethod]
        [TestCategory("MRTDataService")]
        [TestProperty("MRTDataService", "GetMRTUpdateTime")]
        public void GetMRTUpdateTime_回傳日期時間字串()
        {
            // arrange
            var dateTime = new DateTime(2015, 1, 1, 12, 0, 0);
            this._mrtDataRepository.GetMRTUpdateTime().Returns(dateTime);

            var expected = "2015-01-01 12:00:00";

            var sut = this.GetSystemUnderTest();

            // act
            var actual = sut.GetMRTUpdateTime();

            // assert
            actual.Should().NotBeNullOrEmpty();
            actual.Should().Be(expected);
        }
    }
}