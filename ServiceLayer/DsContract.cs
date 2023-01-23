using CommonModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public IList<ContractorDisplay>? cust { get; set; }
        public HttpClient HttpClient;
        public DsContract(HttpClient httpClient, IOptions<APIDetails> apidetails)
        {
            HttpClient = httpClient;
            APIDetails = apidetails.Value;
        }

        public async Task<IList<ContractorDisplay>> GetContract(string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(APIDetails.API.ToString() + "Contractor" + "?PageNumber=" + 0 + "&PageSize=" + 100);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                cust = await JsonSerializer.DeserializeAsync<IList<ContractorDisplay>>(contentstream);

            }
            return cust;
        }


        //Searching by pincode

        public async Task<IList<ContractorDisplay>> SearchBypincode(string token, int pin)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync(APIDetails.API.ToString() + "Customer" + "/Pincode" + "?PageNumber=" + 0 + "&PageSize=" + 100 + "&pin=" + pin);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                cust = await JsonSerializer.DeserializeAsync<IList<ContractorDisplay>>(contentstream);

            }
            return cust;
        }

       
        public async Task CreateContractorDetail(ContractorDetail userMdl, string token)
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

                }
            }
            catch (Exception ex)
            {

            }

        }
        public async Task updatecontractor(ContractorDetail userMdl, string token)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var payload = Newtonsoft.Json.JsonConvert.SerializeObject(userMdl);

                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                // HttpClient.BaseAddress = new Uri(APIDetails.API.ToString());


                HttpResponseMessage httpResponseMessage = await HttpClient.PutAsync(APIDetails.API.ToString() + "Contractor/ContractorUpdate", c);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                    //cust = await JsonSerializer.DeserializeAsync<IList<Contract>>(contentstream);

                }
            }
            catch (Exception ex)
            {

            }
        }
            public async Task deletecontractor(string License, string token)


            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    var payload = Newtonsoft.Json.JsonConvert.SerializeObject(License);

                    HttpResponseMessage httpResponseMessage = await HttpClient.DeleteAsync(APIDetails.API.ToString() + "Contractor" + "?licenseId=" + "'"+License+"'");
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        using var contentstream = await httpResponseMessage.Content.ReadAsStreamAsync();
                        cust = await JsonSerializer.DeserializeAsync<IList<ContractorDisplay>>(contentstream);

                    }
                }

                catch (Exception ex)
                {

                }
            }

            //  return null;
        }
        }
    
