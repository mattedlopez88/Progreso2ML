using Progreso2ML.Models;
using Newtonsoft.Json;
using Stripe.Forwarding;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ThreadNetwork;

namespace Progreso2ML.Services
{
    public class ServiceML
    {
        public async Task<ModelML> GetWeather()
        {
            ModelML dto = null;
            HttpResponseMessage response;

            string requestURL = $"https://api.weatherxu.com/v1/weather?api_key=b3a0d538a908b97cd9e620172fe482c7&lat=40.7128&lon=-74.0060";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = await client.GetAsync(requestURL);
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        dto = JsonConvert.DeserializeObject<ModelML>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dto;
        }
    }
}
