using App2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    class OrdeDetailService : IDataStore<OrderDetail>
    {
        public async Task<bool> AddItemAsync(OrderDetail item)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var responce = await AuthClient.Client.PostAsync(string.Format($"orderdetails"), content);//vytvoř objednávku
       
                return await Task.FromResult(responce.IsSuccessStatusCode);
           
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetail> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetail>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(OrderDetail item)
        {
            throw new NotImplementedException();
        }
    }
}
