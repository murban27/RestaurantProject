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
        RestContext RestContext;
        
        public Task<bool> AddItemAsync(Hyarch item)
        {
            RestContext.Add(item);
            return Task.FromResult(true) ;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            var Item = RestContext.Hyarches.Where(x => x.ID == int.Parse(id)).Select(x=>x).FirstOrDefault();
             RestContext.Remove(Item);
                return Task.FromResult(true);
        }

        public Task<Hyarch> GetItemAsync(string id)
        {
            return Task.FromResult( RestContext.Hyarches.Where(x => x.ID == int.Parse(id)).Select(x => x).FirstOrDefault());
            
        }

        public async Task<IEnumerable<Hyarch>> GetItemsAsync(bool forceRefresh = false)
        {
            return await (from s in RestContext.Hyarches select s).ToListAsync();
            


        }

        public Task<bool> UpdateItemAsync(Hyarch item)
        {
            throw new NotImplementedException();
        }
    }
}
