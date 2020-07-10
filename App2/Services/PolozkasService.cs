using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public class PolozkasService : IDataStore<Items>
    {
   
        public async Task<bool> AddItemAsync(Items item)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var responce = await AuthClient.Client.PostAsync("Items", content);
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
        var responce = await AuthClient.Client.DeleteAsync(string.Format($"Items/{id}"));
        if (responce.IsSuccessStatusCode)
        {
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
    }

        public async Task<Items> GetItemAsync(string id)
        {
            var responce = await AuthClient.Client.GetAsync(string.Format($"Items/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                var zdar = JsonSerializer.Deserialize<Items>(await responce.Content.ReadAsStringAsync());
                return zdar;
            }
            else
            {
                throw new Exception("Something very wrong happened");
            }
        }

        public async Task<IEnumerable<Items>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var responce = await AuthClient.Client.GetAsync(string.Format($"Items"));
                if (responce.IsSuccessStatusCode)
                {
                    var zdar = await responce.Content.ReadAsStringAsync();
                    var pockat = zdar;

                    var ahoj = JsonSerializer.Deserialize<IEnumerable<Items>>(await responce.Content.ReadAsStringAsync());
                    return ahoj;
                }
                else

                {
                    var s = responce.StatusCode;
                    throw new Exception("Something very wrong happened");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateItemAsync(Items item)
        {
            string Id = item.itemId.ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await AuthClient.Client.PutAsync(string.Format($"Items/{Id}"), content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var zdar = (ObservableCollection<Items>)JsonSerializer.Deserialize<ObservableCollection<Items>>(await httpResponseMessage.Content.ReadAsStringAsync());
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);

            }
            else
            {
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);
            }
        }
    }
}
