using System.Collections.Generic;

namespace App.src.resource.mysql.repositories
{
    public interface IBaseRepository<T>
    {
        void Commit();
        void RollBack();
        void Create(T price);
        void Create(IEnumerable<T> prices);
        T Update(T price);
        void Delete(T price);
        IEnumerable<T> ListAll();

    }
}