using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharpDemo;
using TechTalk.SpecFlow;
using RestSharpDemo.Models;

namespace APITest.Features
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUser createUser;
        private IRestResponse response;

        public CreateUserSteps(CreateUser createUser)
        {
            this.createUser = createUser;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUser.name = name;
        }
        
        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUser.job = role;
        }
        
        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var api = new Api();
            response = api.CreateNewUser(BASE_URL, createUser);
        }
        
        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUser>(response);
            Assert.AreEqual(createUser.name, content.name);
            Assert.AreEqual(createUser.job, content.job);
        }
    }
}
