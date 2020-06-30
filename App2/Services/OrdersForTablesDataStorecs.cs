using App2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace App2.Services
{
    public class OrdersForTablesDataStorecs : IDataStore<Order>
    {
        public RestContext RestContext { get; set; }
        public async Task<bool> AddItemAsync(Order item)
        {
          await  RestContext.Orders.AddAsync(item);
           await  RestContext.SaveChangesAsync();
            return await Task.FromResult(true);


        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetItemAsync(Order item)
        {
            var s = RestContext.Orders.Where(x => x.StulId == item.StulId).Select(x => x.Polozky);
            throw new NotImplementedException();
        }

        public Task<Order> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Polozka>>GetPolozkasAsync(Order item,bool forceRefresh=false)
        {
            return  await Task.FromResult((IEnumerable<Polozka>)RestContext.Orders.Where(x => x.StulId == item.StulId && x.IsClosed == false).Select(y => y.Polozky).ToListAsync());
         



        }

        public Task<bool> UpdateItemAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
