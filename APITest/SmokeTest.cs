using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using AventStack.ExtentReports;
using RestSharpDemo;
using RestSharpDemo.Models;
using RestSharpDemo.Models.Request;

namespace APITest
{
    [TestClass]
    public class SmokeTest
    {
        public TestContext TestContext { get; set; }
        public HttpStatusCode statusCode;
        private const string BASE_URL = "https://reqres.in/";

        [ClassInitialize]
        public static void SetupReport(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetUpReport(dir, "SmokeTest", "Smoke test results");
        }

        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

            [TestMethod]
        public void GetListOfUsers()
        {
            var api = new Api();
            var response = api.GetUsers(BASE_URL);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(200, code);
            Reporter.LogToReport(Status.Pass, "200 response code is received");

            var users = HandleContent.GetContent<Users>(response);
            Assert.AreEqual(2, users.page);
        }

        [DeploymentItem("TestData")]
        [TestMethod]
        public void CreateNewUserTest()
        {
            var payload = HandleContent.ParseJson<CreateUserRequest>("CreateUser.json");

            var api = new Api();
            var response = api.CreateNewUser(BASE_URL, payload);
            statusCode = response.StatusCode;
            var code = (int) statusCode;
            Assert.AreEqual(201,code);
            Reporter.LogToReport(Status.Pass, "201 response code is received");

            var userContent = HandleContent.GetContent<CreateUser>(response);
            Assert.AreEqual(payload.name, userContent.name);
        }
    }
}
