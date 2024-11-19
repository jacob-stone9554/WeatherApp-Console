using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherApp_Console.Models;

class WeatherAppMain
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string? apiKey = "";
                string[] cities = ["Parkersburg"]; //, "Morgantown", "Athens"
                string city = "";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";
                string info = ""; // the info being retrieved

                HttpResponseMessage response;
                string responseBody;


                WeatherData data;

                consoleSetup();

                for (int i = 0; i < cities.Length; i++)
                {
                    city = cities[i];
                    info = "current.json";

                    responseBody = await makeApiCall(city, info, url, client); // current info call
                    data = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                    showCurrentData(data);

                    info = "forecast.json";

                    responseBody = await makeApiCall(city, info, url, client);
                    data = JsonConvert.DeserializeObject<WeatherData>(responseBody);
                    showForecastData(data);

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
            }

        }
    }


    public static void consoleSetup()
    {
        Console.SetWindowSize(105, 30);
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(new string('=', 105));
        Console.WriteLine("\r\n░██╗░░░░░░░██╗███████╗░█████╗░████████╗██╗░░██╗███████╗██████╗░░█████╗░██████╗░██████╗░  ██╗░░░██╗░░███╗░░\r\n░██║░░██╗░░██║██╔════╝██╔══██╗╚══██╔══╝██║░░██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗  ██║░░░██║░████║░░\r\n░╚██╗████╗██╔╝█████╗░░███████║░░░██║░░░███████║█████╗░░██████╔╝███████║██████╔╝██████╔╝  ╚██╗░██╔╝██╔██║░░\r\n░░████╔═████║░██╔══╝░░██╔══██║░░░██║░░░██╔══██║██╔══╝░░██╔══██╗██╔══██║██╔═══╝░██╔═══╝░  ░╚████╔╝░╚═╝██║░░\r\n░░╚██╔╝░╚██╔╝░███████╗██║░░██║░░░██║░░░██║░░██║███████╗██║░░██║██║░░██║██║░░░░░██║░░░░░  ░░╚██╔╝░░███████╗\r\n░░░╚═╝░░░╚═╝░░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░  ░░░╚═╝░░░╚══════╝");
        Console.WriteLine(new string('=', 105));
        Console.WriteLine(" {0, -15} | {1, -10} | {2, 5} | {3, 10}", "City", "Temp", "Precip", "Feels Like");
        Console.WriteLine(new string('-', 105));
    }

    public static async Task<string> makeApiCall(string city, string info, string url, HttpClient client)
    {
        string responseBody = "";
        HttpResponseMessage response;
        url = $"http://api.weatherapi.com/v1/{info}?key={Environment.GetEnvironmentVariable("apiKey")}&q={city}&country=UnitedStatesOfAmerica&aqi=no";

        response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }

    public static void showCurrentData(WeatherData data)
    {
        Console.WriteLine(" {0, -15} | {1, -10} | {2, 5} | {3, 10}", data.location.name, 
            data.current.temp_f, data.current.precip_in, data.current.feelslike_f);
    }

    public static void showForecastData(WeatherData data)
    {
        Console.WriteLine(new string('=', 105));
        Console.WriteLine();
    }


}