using ImportCsv.Api.Contracts;
using Microsoft.Extensions.Configuration;

namespace ImportCsv.Api.Domains.price
{
    public class ReadPriceCsv : ReadCsvAbstract<PriceDtc>, IReadPriceCsv<PriceDtc>
    {
        private readonly IConfiguration _configuration;

        public ReadPriceCsv(ISaveCsvPrice<PriceDtc> saveCsvPrice, IConfiguration configuration) : base(saveCsvPrice)
        {
            _configuration = configuration;
        }

        protected override string GetDestinationPath()
        {
            return _configuration["PriceCsv:DestinationPath"];
        }

        protected override string GetOriginFileName()
        {
            return _configuration["PriceCsv:OriginFileName"];
        }

        protected override string GetOriginFilePath()
        {
            return _configuration["PriceCsv:OriginFilePath"];
        }
    }
}