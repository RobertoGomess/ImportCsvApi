using System.Collections.Generic;

namespace ImportCsv.Api.Domains
{
    public interface ISaveCsvAbstract<C>
    {
        bool Execute(IEnumerable<C> list);
    }
}