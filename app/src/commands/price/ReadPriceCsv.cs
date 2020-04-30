using AutoMapper;
using App.src.domains;
using App.src.resource.mysql.models;
using App.src.resource.mysql.repositories;
using Microsoft.Extensions.Configuration;

namespace App.src.commands.price
{
    public class ReadPriceCsv : ReadCsvAbstract<PriceDtc, Price>, IReadPriceCsv<PriceDtc>
    {
        private readonly IConfiguration _configuration;
        
        public ReadPriceCsv(IMapper mapper, IBaseRepository<Price> repository, ISaveCsvPrice<PriceDtc> saveCsvPrice, IConfiguration configuration) : base(mapper, repository, saveCsvPrice)
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