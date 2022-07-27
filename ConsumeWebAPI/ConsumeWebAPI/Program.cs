using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumeWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            async Task GetUsers()
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com") };
                var response = await client.GetAsync("users");
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);
            }

            GetUsers();

            Console.ReadLine();
        }
    }
}
