using AutoMapper;
using App.src.domains;
using App.src.resource.mysql.models;
using App.src.resource.mysql.repositories;

namespace App.src.commands.price
{
    public class SaveCsvPrice : SaveCsvAbstract<PriceDtc, Price>, ISaveCsvPrice<PriceDtc>
    {
        public SaveCsvPrice(IBaseRepository<Price> repository, IMapper mapper) : base(repository, mapper)
        {
        }

    }
}