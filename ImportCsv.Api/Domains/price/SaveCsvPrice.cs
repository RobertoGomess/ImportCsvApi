using AutoMapper;
using ImportCsv.Api.Contracts;
using ImportCsv.Api.Resources.Mysql.Models;
using ImportCsv.Api.Resources.Mysql.Repositories;

namespace ImportCsv.Api.Domains.price
{
    public class SaveCsvPrice : SaveCsvAbstract<PriceDtc, Price>, ISaveCsvPrice<PriceDtc>
    {
        public SaveCsvPrice(IBaseRepository<Price> repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}