using Android.OS;
using App2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public class OrderInfoServices : IDataStore<Orders>
    {
        public async Task<Orders> AddItemAsync(Orders item)
        { 

            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var responce = await AuthClient.Client.PostAsync(string.Format($"Orders"),content);//vytvoř objednávku
            if(responce.IsSuccessStatusCode)
            {
                var s = await responce.Content.ReadAsStringAsync();// Přečti a vrat objednávku
                var DeseRialize = JsonSerializer.Deserialize<Orders>(s);
                return DeseRialize;
            }
            else
            {
                return null;
            }
            
  
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
        /// <summary>
        /// Updatni objednávky
        /// </summary>
        /// <param name="item"> Objednávka </param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(Orders item)
        {
            string id = item.id.ToString();
           

            StringContent stringContent = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8);
            try
            {
                var responce = await AuthClient.Client.PutAsync(string.Format($"Orders/{id}"), stringContent);
                if (responce.IsSuccessStatusCode)
                {
                    var s = await responce.Content.ReadAsStringAsync();
                    string message = s;

                    var deserialize = JsonSerializer.Deserialize<Orders>(await responce.Content.ReadAsStringAsync());
                    return await Task.FromResult(responce.IsSuccessStatusCode);
                }
                else
                {
                    throw new Exception(responce.StatusCode.ToString());

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        Task<bool> IDataStore<Orders>.AddItemAsync(Orders item)
        {
            throw new NotImplementedException();
        }
    }
}
