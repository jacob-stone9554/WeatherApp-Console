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
                string[] cities = ["Parkersburg", "Morgantown", "Athens"];
                string city = "";
                string url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                HttpResponseMessage response;
                string responseBody;


                WeatherData data;

                consoleSetup();

                for (int i = 0; i < cities.Length; i++)
                {
                    city = cities[i];

                    url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&country=UnitedStatesOfAmerica&aqi=no";

                    response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<WeatherData>(responseBody);

                    showCurrentData(data);
                }

               // Console.WriteLine(Console.WindowHeight + " " + Console.WindowWidth);


                //while (true)
                //{
                //    Console.WriteLine("Press 1 to get weather data! \nPress 2 to exit!");
                //    ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                //    if (keyInfo.Key == ConsoleKey.D1)
                //    {
                //        Console.Clear();   
                //        Console.WriteLine(data.location.name + ": " + data.current.temp_f + " degrees fahrenheit");
                //        Console.WriteLine("Last updated: " + data.current.last_updated);
                //    }
                //    else if (keyInfo.Key == ConsoleKey.D2)
                //    {
                //        return;
                //    }
                //}
                //

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

    public static void showCurrentData(WeatherData data)
    {
        Console.WriteLine(" {0, -15} | {1, -10} | {2, 5} | {3, 10}", data.location.name, 
            data.current.temp_f, data.current.precip_in, data.current.feelslike_f);
    }
}