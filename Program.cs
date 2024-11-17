using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp_Console;

class WeatherAppMain
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string? apiKey = Environment.GetEnvironmentVariable("apiKey");

                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q=Parkersburg&aqi=no";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                WeatherData data = JsonConvert.DeserializeObject<WeatherData>(responseBody);


                Console.WriteLine(data.location.name + ": " + data.current.temp_f + " degrees fahrenheit");
                Console.WriteLine("Last updated: " + data.current.last_updated);
                //Console.WriteLine(responseBody);

                
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }

        }
    }
}