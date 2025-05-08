using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace YourNamespace.StepDefinitions
{
    [Binding]
    public class LoginSteps : IClassFixture<WebApplicationFactory<Program>>
    {
        private string _username;
        private string _password;
        private bool _isLoggedIn;
        private HttpClient _httpClient;

        public LoginSteps(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }   
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
            var httpClient = new HttpClient();
            var tokenEndpoint = "https://localhost:7226/api/users";

            var response = await _httpClient.PostAsJsonAsync("api/users",new { firstName, lastName } );

            var get = await _httpClient.GetAsync("api/users");

            var body = await get.Content.ReadAsStringAsync();
            _isLoggedIn = response.IsSuccessStatusCode;
        }

        [Then(@"the user should be logged in successfully")]
        public void ThenTheUserShouldBeLoggedInSuccessfully()
        {
            NUnit.Framework.Assert.That(_isLoggedIn, "Login should be successful with valid credentials.");
        }
    }
}
