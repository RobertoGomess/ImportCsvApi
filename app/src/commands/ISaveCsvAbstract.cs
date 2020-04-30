using System.Collections.Generic;

namespace App.src.commands
{
    public interface ISaveCsvAbstract<C>
    {
        bool Execute(IEnumerable<C> list);
    }
}