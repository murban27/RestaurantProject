using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App2.Services
{
    public class HyarchServices : IDataStore<Hyarch>

    {
        public Task<bool> AddItemAsync(Hyarch item)
        {
            App2.App.RestContext.Add(item);
            return Task.FromResult(true) ;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            var Item = App2.App.RestContext.Hyarches.Where(x => x.ID == int.Parse(id)).Select(x=>x).FirstOrDefault();
              App2.App.RestContext.Remove(Item);
                return Task.FromResult(true);
        }

        public Task<Hyarch> GetItemAsync(string id)
        {
            return Task.FromResult( App2.App.RestContext.Hyarches.Where(x => x.ID == int.Parse(id)).Select(x => x).FirstOrDefault());
            
        }

        public async Task<IEnumerable<Hyarch>> GetItemsAsync(bool forceRefresh = false)
        {
            return await (from s in App.RestContext.Hyarches select s).ToListAsync();
            


        }

        public Task<bool> UpdateItemAsync(Hyarch item)
        {
            throw new NotImplementedException();
        }
    }
}
