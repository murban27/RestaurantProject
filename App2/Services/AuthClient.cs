using App2.Models;
using App2.Views;
using Syncfusion.XForms.AvatarView;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App2.Services
{
    public static class AuthClient
    {
        public static HttpClient Client { get; set; }
        public static Models.Login Login { get; set; }



        public static void SetProperties()
        {


            var AuthValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(Login.Login1+":"+Login.Password )));
           

            Client = new HttpClient() { DefaultRequestHeaders = { Authorization = AuthValue }, BaseAddress = new Uri("http://vspj.azurewebsites.net/api/") };

        }
        public async static Task<bool> AuthorizationClient()
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(Login), Encoding.UTF8, "application/json");
      

         var responce= await  Client.PostAsync("logins/authenticate", content);
            if(responce.IsSuccessStatusCode)
            {

                var odpoved = JsonSerializer.Deserialize<Models.Login>(await responce.Content.ReadAsStringAsync());
                odpoved.Password = Login.Password;
                odpoved.Login1 = Login.Login1;
                Login = odpoved;
                return true;
               
                }
            else
            {
                return false;
            }

              


        }

    }
}
