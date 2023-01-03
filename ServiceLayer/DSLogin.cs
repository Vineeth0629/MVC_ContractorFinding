using CommonModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ServiceLayer
{
    public class DSLogin: IDSLogin
    {
        public APIDetails APIDetails { get; set; }
        public IList<Login> Login { get; set; }
        public HttpClient HttpClient;
        public DSLogin(HttpClient httpClient,IOptions<APIDetails> apidetails)
        {
            HttpClient = httpClient;
            APIDetails =apidetails.Value;
        }

        public async Task<IList<Login>> Logins()
        {
            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(APIDetails.API.ToString() + "User");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream=await httpResponseMessage.Content.ReadAsStreamAsync();
                Login = await JsonSerializer.DeserializeAsync<IList<Login>>(contentstream);

            }
            return Login;
        }

        public async Task<string> ValidateUser(TbUser userMdl)
        {
            string msg = "";
            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
               // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync(APIDetails.API.ToString()+"User/login", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    TokenDetails data = await JsonSerializer.DeserializeAsync<TokenDetails>(contentstream);
                    msg= data.Message;
                }
            }
            catch(Exception ex)
            {
                return "";
            }
            return msg;
        }
        public async Task<IEnumerable<Login>> postLogins(string emailId,string password)
        {
            //var json=JsonConvert.SerializeObject( user);
            //var data=new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync(APIDetails.API.ToString() + "User",new StringContent("?emailId=" + emailId + "?password=" + password));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                var response = await HttpClient.GetStreamAsync(APIDetails.API.ToString());
            }
            return Login;
        }

    }
}
