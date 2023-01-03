using CommonModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DsContract: IDsContract
    {
        public APIDetails APIDetails { get; set; }
        public IList<Contract> cust { get; set; }
        public HttpClient HttpClient;
        public DsContract(HttpClient httpClient, IOptions<APIDetails> apidetails)
        {
            HttpClient = httpClient;
            APIDetails = apidetails.Value;
        }

        public async Task<IList<Contract>> GetContract(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(APIDetails.API.ToString() + "Contractor" + "?PageNumber=" + 0 + "&PageSize=" + 100);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                cust = await JsonSerializer.DeserializeAsync<IList<Contract>>(contentstream);

            }
            return cust;
        }
    }
}
