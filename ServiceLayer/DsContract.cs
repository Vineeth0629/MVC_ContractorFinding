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
    public class DsContract : IDsContract
    {
        public APIDetails APIDetails { get; set; }
        public IList<Contract>? cust { get; set; }
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
        public async Task InsertContractor(Contract userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PostAsync(APIDetails.API.ToString() + "Contractor", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    cust = await JsonSerializer.DeserializeAsync<IList<Contract>>(contentstream);

                }
            }
            catch (Exception ex)
            {

            }

        }
        public async Task updatecontractor(Contract userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PutAsync(APIDetails.API.ToString() + "Contractor/Contractorupdate", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    cust = await JsonSerializer.DeserializeAsync<IList<Contract>>(contentstream);

                }
            }
            catch (Exception ex)
            {

            }

            //public async Task deletecontractor(string contractId, string token)

            //{
            //    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //    try
            //    {
            //        var payload = Newtonsoft.Json.JsonConvert.SerializeObject(contractId);

            //        //HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            //        // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


            //        HttpResponseMessage httpResponseMessage = await HttpClient.DeleteAsync(APIDetails.API.ToString() + "Contractor" + "?ContractorId=" + contractId);
            //        if (httpResponseMessage.IsSuccessStatusCode)
            //        {
            //            using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
            //            cust = await JsonSerializer.DeserializeAsync<IList<Contract>>(contentstream);

            //        }
            //    }

            //    catch (Exception ex)
            //    {

            //    }
            //}

            //  return null;
        }
    }
}