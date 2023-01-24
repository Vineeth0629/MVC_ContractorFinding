using CommonModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DSRegistration : IDSRegistration
    {
        public APIDetails APIDetails { get; set; }
        public IList<Registration> Registration { get; set; }
        public HttpClient HttpClient;
        public DSRegistration(HttpClient httpClient, IOptions<APIDetails> apidetails)
        {
            HttpClient = httpClient;
            APIDetails = apidetails.Value;
        }

        public async Task<Boolean> Registrations(Registration regModel)
        {
         

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(regModel);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PutAsync(APIDetails.API.ToString() + "User", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    bool isSuccess= await JsonSerializer.DeserializeAsync<Boolean>(contentstream);
                    return isSuccess;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

    }
}
