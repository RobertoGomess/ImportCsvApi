using System.Collections.Generic;

namespace ImportCsv.app.commands
{
    public interface ISaveCsvAbstract<C>
    {
        bool Execute(IEnumerable<C> list);
    }
}