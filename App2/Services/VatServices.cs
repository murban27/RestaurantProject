using App2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public class VatServices : IDataStore<VAT>
        

    {
        public RestContext RestContext;
        public Task<bool> AddItemAsync(VAT item)
        {
           RestContext.Add(item);
           RestContext.SaveChanges();

            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<VAT> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VAT>> GetItemsAsync(bool forceRefresh = false)
        {
            return await RestContext.Dane.ToListAsync();
        }

        public Task<bool> UpdateItemAsync(VAT item)
        {
            throw new NotImplementedException();
        }
    }
}
