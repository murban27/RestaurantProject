using App2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public class StolyDataService : IDataStore<Stoly>

    {

        RestContext RestContext;
        public async Task<bool> AddItemAsync(Stoly item)
        {
        
      
            await App.RestContext.Stolies.AddAsync(item);
            App.RestContext.SaveChanges();
            return await Task.FromResult(true);
        }
 

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Stoly> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Stoly>> GetItemsAsync(bool forceRefresh = false)
        {
            return await App.RestContext.Stolies.ToListAsync();
          

        }

        public async Task<bool> UpdateItemAsync(Stoly item)
        {
             App.RestContext.Stolies.Update(item);
            App.RestContext.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
