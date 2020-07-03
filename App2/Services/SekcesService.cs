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
    public class SekcesService : IDataStore<Sekce>
    {
        public System.Collections.ObjectModel.ObservableCollection<Sekce> Sekces { get; set; }

        public async Task<bool> AddItemAsync(Sekce item)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var responce = await AuthClient.Client.PostAsync("Sekces", content);
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
            var responce = await AuthClient.Client.DeleteAsync(string.Format($"Sekces/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Sekce> GetItemAsync(string id)
        {
            var responce = await AuthClient.Client.GetAsync(string.Format($"Sekces/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                var zdar = JsonSerializer.Deserialize<Sekce>(await responce.Content.ReadAsStringAsync());
                return zdar;
            }
            else
            {
                throw new Exception("Something very wrong happened");
            }
        }

        public async Task<IEnumerable<Sekce>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var responce = await AuthClient.Client.GetAsync(string.Format($"Sekces"));
                if (responce.IsSuccessStatusCode)
                {
                    var zdar = await responce.Content.ReadAsStringAsync();
                    var pockat = zdar;

                    var ahoj = JsonSerializer.Deserialize<IEnumerable<Sekce>>(await responce.Content.ReadAsStringAsync());
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

        public async Task<bool> UpdateItemAsync(Sekce item)
        {
            string Id = item.id.ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await AuthClient.Client.PutAsync(string.Format($"Sekces/{Id}"), content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var zdar = (ObservableCollection<Tables>)JsonSerializer.Deserialize<ObservableCollection<Tables>>(await httpResponseMessage.Content.ReadAsStringAsync());
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);

            }
            else
            {
                return await Task.FromResult(httpResponseMessage.IsSuccessStatusCode);
            }
        }
    }
}
