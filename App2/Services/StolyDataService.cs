using App2.Models;
using App2.Views;
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
    public class StolyDataService : IDataStore<Tables>
    {
        public System.Collections.ObjectModel.ObservableCollection<Tables> Stolies { get; set; }


        public async Task<bool> AddItemAsync(Tables item)
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

        public async Task<Tables> GetItemAsync(string id)
        {

            var responce = await AuthClient.Client.GetAsync(string.Format($"Tables/{id}"));
            if (responce.IsSuccessStatusCode)
            {
                var zdar = JsonSerializer.Deserialize<Tables>(await responce.Content.ReadAsStringAsync());
                return zdar;
            }
            else
            {
                throw new Exception("Something very wrong happened");
            }
        }


        public async Task<bool> UpdateItemAsync(Tables stul)
        {
            string Id = stul.id.ToString();
            StringContent content = new StringContent(JsonSerializer.Serialize(stul), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await AuthClient.Client.PutAsync(string.Format($"Tables/{Id}"), content);
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

        public async Task<IEnumerable<Tables>> GetItemsAsync(bool forceRefresh)
        {
            try
            {
                var responce = await AuthClient.Client.GetAsync(string.Format($"Tables"));
                if (responce.IsSuccessStatusCode)
                {
                    var zdar = await responce.Content.ReadAsStringAsync();
                   var pockat = zdar;

                    var ahoj = JsonSerializer.Deserialize<IEnumerable<Tables>>(await responce.Content.ReadAsStringAsync());
                    return ahoj;
                }
                else
     
                {
                    var s = responce.StatusCode;
                    throw new Exception("Something very wrong happened");
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}