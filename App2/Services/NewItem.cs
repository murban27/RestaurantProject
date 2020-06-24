using App2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public class NewItem : IDataStore<Polozka>
    {
        public async Task<bool> AddItemAsync(Polozka item)
        {
            App.RestContext.Polozkas.Add(item);
            return await Task.FromResult(true);
            
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Polozka> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Polozka>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult((IEnumerable<Polozka>)App.RestContext.Polozkas.Select(x => x).ToListAsync());
        }

            public async Task<bool> UpdateItemAsync(Polozka item)
        {
            throw new NotImplementedException();
        }
    }
}
