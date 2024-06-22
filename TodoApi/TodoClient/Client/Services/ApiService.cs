using TodoApi.Models; 

namespace TodoClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // public async Task<List<Goal>> GetGoals()
        // {
        //     return await _httpClient.GetFromJsonAsync<List<Goal>>("api/goals");
        // }

        // public async Task<Goal> GetGoal(int id)
        // {
        //     return await _httpClient.GetFromJsonAsync<Goal>($"api/goals/{id}");
        // }

        // public async Task CreateGoal(Goal goal)
        // {
        //     await _httpClient.PostAsJsonAsync("api/goals", goal);
        // }

        // public async Task UpdateGoal(int id, Goal goal)
        // {
        //     await _httpClient.PutAsJsonAsync($"api/goals/{id}", goal);
        // }

        // public async Task DeleteGoal(int id)
        // {
        //     await _httpClient.DeleteAsync($"api/goals/{id}");
        // }
    }
}
