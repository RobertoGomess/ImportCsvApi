using AutoMapper;
using ImportCsv.app.domains;
using ImportCsv.app.resource.mysql.models;

namespace ImportCsv.app.Profiles
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