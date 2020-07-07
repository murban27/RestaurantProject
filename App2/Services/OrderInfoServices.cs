using Android.OS;
using App2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public class OrderInfoServices : IDataStore<Orders>
    {
        public Task<bool> AddItemAsync(Orders item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Orders> GetItemAsync(string id)
        {
            try
            {
                var responce = await AuthClient.Client.GetAsync(string.Format($"Orders/{id}"));
                if (responce.IsSuccessStatusCode)
                {
                    var s = await responce.Content.ReadAsStringAsync();
                    string message = s;

                    var deserialize = JsonSerializer.Deserialize<Orders>(await responce.Content.ReadAsStringAsync());
                    return deserialize;
                }
                else
                {
                    throw new Exception(responce.StatusCode.ToString());
                        
                }
            }
            catch(Exception e)
            {

                throw new Exception(e.Message);
            }
         
        }

        public Task<IEnumerable<Orders>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }  

        public Task<bool> UpdateItemAsync(Orders item)
        {
            throw new NotImplementedException();
        }
    }
}
