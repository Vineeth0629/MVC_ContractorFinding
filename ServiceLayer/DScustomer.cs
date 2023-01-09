using CommonModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DScustomer : IDScustomer
    {
        public APIDetails APIDetails { get; set; }
        public IList<customer>? cust { get; set; }
        public HttpClient HttpClient;
        public DScustomer(HttpClient httpClient, IOptions<APIDetails> apidetails)
        {
            HttpClient = httpClient;
            APIDetails = apidetails.Value;
        }

        public async Task<IList<customer>> GetCustomer(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(APIDetails.API.ToString() + "Customer" + "?PageNumber=" + 0 + "&PageSize=" + 100);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                cust = await JsonSerializer.DeserializeAsync<IList<customer>>(contentstream);

            }
            return cust;
        }
        public async Task InsertCustomer(customer userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync(APIDetails.API.ToString() + "Customer", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    cust = await JsonSerializer.DeserializeAsync<IList<customer>>(contentstream);

                }
            }
            catch (Exception ex)
            {

            }

          //  return null;
        }
        public async Task UpdateCustomer(customer userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PutAsync(APIDetails.API.ToString() + "Customer/CustomerUpdate", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    cust = await JsonSerializer.DeserializeAsync<IList<customer>>(contentstream);

                }
            }
            catch (Exception ex)
            {

            }

            //  return null;
        }
        public async Task deleteCustomer(customer userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using (var shoppingCartClient = new HttpClient())
            {
                var response = await shoppingCartClient.DeleteAsync(APIDetails.API.ToString() + "Customer");
                response.EnsureSuccessStatusCode();
            }
            //return "";

        }
    }
}
