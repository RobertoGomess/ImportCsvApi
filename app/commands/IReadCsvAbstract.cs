using System.Collections.Generic;

namespace ImportCsv.app.commands
{
    public interface IReadCsvAbstract<C>
    {
        IEnumerable<C> Execute();
    }
}