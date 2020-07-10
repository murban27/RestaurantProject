using App2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public class StolyBackupDataService : IDataStore<StolyBackup>
        
    {
        public  RestContext RestContext;
        public async Task<bool> AddItemAsync(StolyBackup item)
        {
        
      
            await RestContext.Stolies.AddAsync(item);
           RestContext.SaveChanges();
            return await Task.FromResult(true);
        }
 

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<StolyBackup> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StolyBackup>> GetItemsAsync(bool forceRefresh = false)
        {
            return await RestContext.Stolies.ToListAsync();
          

        }

        public async Task<bool> UpdateItemAsync(StolyBackup item)
        {
            RestContext.Stolies.Update(item);
           RestContext.SaveChanges();
            return await Task.FromResult(true);
        }
    }
}
