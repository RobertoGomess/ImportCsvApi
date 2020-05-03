using System.Collections.Generic;

namespace ImportCsv.Api.Domains
{
    public interface IReadCsvAbstract<C>
    {
        IEnumerable<C> Execute();
    }
}