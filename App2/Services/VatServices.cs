using App2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public class VatServices : IDataStore<VAT>
    {
        public async Task<bool> AddItemAsync(VAT item)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var responce = await AuthClient.Client.PostAsync("VATS", content);
            if (responce.IsSuccessStatusCode)
            {

                return await Task.FromResult(true);

            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<VAT> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VAT>> GetItemsAsync(bool forceRefresh = false)
        {
            
                var responce = await AuthClient.Client.GetAsync(string.Format($"VATS"));
                if (responce.IsSuccessStatusCode)
                {
                    var zdar = await responce.Content.ReadAsStringAsync();
                    var pockat = zdar;

                    var ahoj = JsonSerializer.Deserialize<IEnumerable<VAT>>(await responce.Content.ReadAsStringAsync());
                    return ahoj;
                }
                else

                {
                    var s = responce.StatusCode;
                    throw new Exception("Something very wrong happened");
                }
         
        }

        public async Task<bool> UpdateItemAsync(VAT item)
        {
            string Id = item.vatId.ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await AuthClient.Client.PutAsync(string.Format($"VATS/{Id}"), content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);

            }
            else
            {
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);
            }
        }
    }
}
