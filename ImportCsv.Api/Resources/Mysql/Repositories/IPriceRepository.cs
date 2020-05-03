using System;

namespace ImportCsv.Api.Resources.Mysql.Repositories
{
    public interface IPriceRepository<T> : IBaseRepository<T>, IDisposable
    {
    }
}