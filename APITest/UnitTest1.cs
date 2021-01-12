using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;

namespace APITest
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://reqres.in/";

        [TestMethod]
        public void TestMethod1()
        {
            var api = new Demo();
            var response = api.GetUsers(BASE_URL);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(200, code);

            var users = HandleContent.GetContent<Users>(response);
            Assert.AreEqual(2, users.page);
        }

        [DeploymentItem("TestData")]
        [TestMethod]
        public void CreateNewUserTest()
        {
            var payload = HandleContent.ParseJson<CreateUserRequest>("CreateUser.json");

            var api = new Demo();
            var response = api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int) statusCode;
            Assert.AreEqual(201,code);

            var userContent = HandleContent.GetContent<CreateUserResponse>(response);
            Assert.AreEqual(payload.name, userContent.name);
        }
    }
}
