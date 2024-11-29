using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json; 

namespace pogoda_smiecia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,relative_humidity_2m,weather_code,surface_pressure,wind_speed_10m&forecast_days=1";
            HttpResponseMessage response = client.GetAsync(url).Result;
            string json = response.Content.ReadAsStringAsync().Result;
            richTextBox1.Text = json;
            APIResponse apiResponse = JsonConvert.DeserializeObject<APIResponse>(json);
            TemperatureTextBox.Text = apiResponse.current.temperature_2m.ToString();
            TemperatureTextBox.Text += " ";
            TemperatureTextBox.Text += apiResponse.current_units.temperature_2m;

        }
    }



}
