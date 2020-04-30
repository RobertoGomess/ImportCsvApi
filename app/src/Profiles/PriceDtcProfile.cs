using AutoMapper;
using App.src.domains;
using App.src.resource.mysql.models;

namespace App.src.Profiles
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