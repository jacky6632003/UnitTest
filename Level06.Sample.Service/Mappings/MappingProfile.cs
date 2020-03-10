using AutoMapper;
using Level06.Sample.Repository.Models;
using Level06.Sample.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level06.Sample.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<MRTLineModel, MRTLineDto>()
                .ForMember(d => d.Sort, opt => opt.MapFrom(s => s.Sort))
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.MRTLineID))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.MRTLineName))
                .ForMember(d => d.Area, opt => opt.MapFrom(s => s.Area));

            this.CreateMap<MRTStationModel, MRTStationDto>()
                .ForMember(d => d.Sort, opt => opt.MapFrom(s => s.Sort))
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.MRTStationID))
                .ForMember(d => d.MRTLine, opt => opt.MapFrom(s => s.MRTLine))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.MRTStationName))
                .ForMember(d => d.County, opt => opt.MapFrom(s => s.County))
                .ForMember(d => d.District, opt => opt.MapFrom(s => s.District))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(s => s.Latitude))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(s => s.Longitude));

            this.CreateMap<SchoolInfoModel, SchoolInfoDto>();
        }
    }
}