using System.Collections.Generic;

namespace ImportCsv.Api.Resources.Mysql.Repositories
{
    public interface IBaseRepository<T>
    {
        void Commit();
        void RollBack();
        void Create(T price);
        void Create(IEnumerable<T> prices);
        T Update(T price);
        void Delete(T price);
        void DeleteAll();
        IEnumerable<T> ListAll();

    }
}