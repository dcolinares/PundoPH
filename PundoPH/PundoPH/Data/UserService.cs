using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using PundoPH.Model;
using System.Net.Http;

namespace PundoPH.Data
{
    public class UserService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _jsRuntime;

        // Constructor to inject AppDbContext
        public UserService(HttpClient httpClient, IJSRuntime jSRuntime)
        {
            _http = httpClient;
            _jsRuntime = jSRuntime;
        }

        // Method to fetch user details
        public async Task<User?> GetUser(string userName, string password)
        {
            var response = await _http.GetAsync($"api/user/get?userName={userName}&password={password}");
            var user = await response.Content.ReadFromJsonAsync<User>();
            return user;
        }

        public async Task<string> SaveCreateUser(User user)
        {
            var response = await _http.PostAsJsonAsync("api/user/create", user);
            var result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public string ResetPassword(int userID, string password)
        {
            var response = _http.PostAsJsonAsync($"api/user/update-password?userID={userID}&password={password}", new { });
            var result = response.Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        public User? CurrentUser { get; set; }
    }
}
