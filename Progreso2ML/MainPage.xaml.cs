using Newtonsoft.Json;
using Progreso2ML.Models;

namespace Progreso2ML
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
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
        }
    }

}
