using System.Collections.Generic;

namespace App.src.commands
{
    public interface IReadCsvAbstract<C>
    {
        IEnumerable<C> Execute();
    }
}