using System;
using System.Collections.Generic;
using System.Linq;
using App.src.resource.mysql.models;

namespace App.src.resource.mysql.repositories
{
    public class PriceRepository : IPriceRepository<Price>, IDisposable
    {
        private ImportDbContext context;

        public PriceRepository(ImportDbContext context)
        {
            this.context = context;
        }

        public void Create(Price price)
        {
            throw new NotImplementedException();
        }

        public void Delete(Price price)
        {
            throw new NotImplementedException();
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

        public void Create(IEnumerable<Price> prices)
        {
            foreach (var price in prices)
            {
                price.CreatedDate = DateTime.Now;
                price.ModifieldDate = DateTime.Now;
            }
            context.Prices.AddRange(prices);
        }
    }
}