using CommonModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        public async Task<Boolean> ValidateUser(TbUser userMdl)
        {
            var payload = Newtonsoft.Json.JsonConvert.SerializeObject( userMdl);

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());

            c.Headers.Add("", "");
            HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync("User/login",c );
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                Login = await JsonSerializer.DeserializeAsync<IList<Login>>(contentstream);

            }
            return true;
        }

    }
}
