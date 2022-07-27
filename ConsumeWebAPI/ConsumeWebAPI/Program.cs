using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
            var response = client.GetAsync("users");
            response.Wait();

            if (response.IsCompleted)
            {
                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var message = result.Content.ReadAsStringAsync();
                    message.Wait();
                    Console.WriteLine("Message from WebAPI: " + message.Result);

                    var jsonObject = JsonConvert.DeserializeObject(message.Result);

                    Console.WriteLine("Json Object: " + jsonObject);
                }
            }

            Console.ReadLine();
        }
    }
}
