using App2.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public class StolyDataService : IDataStore<Stoly>
    {
        public IEnumerable<Stoly> Stolies { get; set; }


        public async Task<bool> AddItemAsync(Stoly item)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
           var responce = await AuthClient.Client.PostAsync("Tables", content);
            if (responce.IsSuccessStatusCode)
            {
       
                return await Task.FromResult(true);
                
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
           
            var responce = await AuthClient.Client.DeleteAsync(string.Format($"Tables/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Stoly> GetItemAsync(string id)
        {
            
            var responce = await AuthClient.Client.GetAsync(string.Format($"Tables/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                var zdar = JsonSerializer.Deserialize<Stoly>(await responce.Content.ReadAsStringAsync());
                return zdar;
            }
            else
            {
                throw new Exception("Something very wrong happened");
            }
        }

        public async Task<IEnumerable<Stoly>> GetItemsAsync(bool forceRefresh = false)
        {
            var responce = await AuthClient.Client.GetAsync(string.Format($"Tables"));
            if (responce.IsSuccessStatusCode)
            {
                var zdar = (IEnumerable<Stoly>)JsonSerializer.Deserialize<Stoly>(await responce.Content.ReadAsStringAsync());
                return zdar;
            }
            else
            {
                throw new Exception("Something very wrong happened");
            }
        }

        public async Task<bool> UpdateItemAsync(Stoly stul)
        {
            string Id = stul.Id.ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(stul), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage= await AuthClient.Client.PutAsync(string.Format($"Tables/{Id}"),content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var zdar = (IEnumerable<Stoly>)JsonSerializer.Deserialize<Stoly>(await httpResponseMessage.Content.ReadAsStringAsync());
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);

            }
            else
            {
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);
            }
        }
    }
}
