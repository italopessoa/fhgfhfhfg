using System.Collections.Generic;
using System.Threading.Tasks;
using AppLAB3.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System;

namespace AppLAB3
{
    public static class Api
    {
        public static async Task<List<Tag>> GetTagAsync()
        {
            try
            {
                const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.
                    Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    {
                        return JsonConvert.DeserializeObject<List<Tag>>(await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));
                    }
                }
            }
            catch(Exception ex)
            {
                string a = ex.Message;   
            }
            return null;
        }
    }
}
