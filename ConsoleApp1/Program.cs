using System;
using System.Net.Http;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Connections");
            SendRequests();
            Console.ReadLine();
        }
        private static async void SendRequests()
        {
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var result = await client.GetAsync("http://danpatrascu.com");
                    Console.WriteLine(result.StatusCode);
                }
            }
            Console.WriteLine("conncetions Done");
        }
    }
}
