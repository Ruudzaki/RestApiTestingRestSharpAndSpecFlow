using System;
using RestSharp;

namespace ApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("/api/users?page=2", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Console.ReadKey();
        }
    }
}
