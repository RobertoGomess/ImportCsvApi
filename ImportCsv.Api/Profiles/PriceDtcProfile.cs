using AutoMapper;
using ImportCsv.Api.Contracts;
using ImportCsv.Api.Resources.Mysql.Models;

namespace ImportCsv.Api.Profiles
{
    public class PriceDtcProfile : Profile
    {
        public PriceDtcProfile()
        {
            CreateMap<PriceDtc, Price>();
            CreateMap<Price, PriceDtc>();
        }
    }
}