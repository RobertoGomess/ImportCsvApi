using AutoMapper;
using ImportCsv.Api.Contracts;
using ImportCsv.Api.Resources.Mysql.Models;

namespace ImportCsv.Api.Profiles
{
    public class CheckPriceResolver: IValueResolver<PriceDtc, Price, float>
    {

        public float Resolve(PriceDtc source, Price destination, float destMember, ResolutionContext context)
        {
            if(source.AmountPrice <= 0){
                throw new AutoMapperMappingException($"Invalid value for field {nameof(source.AmountPrice)}");
            }
            return source.AmountPrice;
        }
    }
}