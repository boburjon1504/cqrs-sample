using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Net.Http.Json;

namespace YourNamespace.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private string _username;
        private string _password;
        private bool _isLoggedIn;

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            // Simulate loading the login page
            _username = string.Empty;
            _password = string.Empty;
            _isLoggedIn = false;
        }

        [When(@"the user enters username ""(.*)"" and password ""(.*)""")]
        public async Task WhenTheUserEntersUsernameAndPasswordAsync(string firstName, string lastName)
        {
            _username = firstName;
            _password = lastName;
            var httpClient = new HttpClient();
            var tokenEndpoint = "https://localhost:7226/api/users";

            //var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint)
            //{
            //    Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //    {
            //        ["grant_type"] = "password",
            //        ["client_id"] = "report-hub",
            //        ["client_secret"] = "client_secret_key",
            //        ["scope"] = "report-hub-api-scope roles offline_access",
            //        ["username"] = _username,
            //        ["password"] = _password
            //    })
            //};

            var response = await httpClient.PostAsJsonAsync(tokenEndpoint,new { _username, _password } );

            _isLoggedIn = response.IsSuccessStatusCode;
        }

        [Then(@"the user should be logged in successfully")]
        public void ThenTheUserShouldBeLoggedInSuccessfully()
        {
            NUnit.Framework.Assert.That(_isLoggedIn, "Login should be successful with valid credentials.");
        }
    }
}
