using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public class OrdersForTablesDataStorecs : IDataStore<Order>
    {
        public async Task<bool> AddItemAsync(Order item)
        {
          await  App.RestContext.Orders.AddAsync(item);
            App.RestContext.SaveChanges();
            return await Task.FromResult(true);


        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
