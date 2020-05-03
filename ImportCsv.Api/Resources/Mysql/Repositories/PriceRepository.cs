using ImportCsv.Api.Resources.Mysql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImportCsv.Api.Resources.Mysql.Repositories
{
    public class PriceRepository : IPriceRepository<Price>
    {
        private readonly ImportDbContext context;

        public PriceRepository(ImportDbContext context)
        {
            this.context = context;
        }

        public void Create(Price price)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<Price> prices)
        {
            foreach (var price in prices)
            {
                price.CreatedDate = DateTime.Now;
                price.ModifieldDate = DateTime.Now;
            }
            context.Prices.AddRange(prices);
        }

        public void Delete(Price price)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            context.Prices.RemoveRange(context.Prices);
        }

        public IEnumerable<Price> ListAll()
        {
            return context.Prices.ToList();
        }

        public Price Update(Price price)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}