using AutoMapper;
using ImportCsv.app.domains;
using ImportCsv.app.resource.mysql.models;
using ImportCsv.app.resource.mysql.repositories;

namespace ImportCsv.app.commands.price
{
    public class SaveCsvPrice : SaveCsvAbstract<PriceDtc, Price>, ISaveCsvPrice<PriceDtc>
    {
        public SaveCsvPrice(IBaseRepository<Price> repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}