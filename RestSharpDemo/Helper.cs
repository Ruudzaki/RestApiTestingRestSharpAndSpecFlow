using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.CSharp;

namespace RestSharpDemo
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);

            return client;
        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");

            return request;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", payload, ParameterType.RequestBody);

            return request;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            request = new RestRequest(Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json",payload,ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }


    }
}
