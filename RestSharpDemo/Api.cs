using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using RestSharpDemo.Models;

namespace RestSharpDemo
{
    public class Api
    {
        private readonly Helper helper;

        public Api()
        {
            helper = new Helper();
        }

        public IRestResponse GetUsers(string baseUrl)
        {
            var client = helper.SetUrl(baseUrl,"api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            return response;
        }

        public IRestResponse CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest(jsonString);
            var response = helper.GetResponse(client, request);
            return response;
        }
    }
}
