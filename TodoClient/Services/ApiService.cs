using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoClient.Models;
using TaskModel = TodoClient.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace TodoClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Goal>> GetGoals()
        {
            return await _httpClient.GetFromJsonAsync<List<Goal>>("api/goals");
        }

        public async Task<Goal> GetGoal(int id)
        {
            return await _httpClient.GetFromJsonAsync<Goal>($"api/goals/{id}");
        }

        public async Task CreateGoal(Goal goal)
        {
            await _httpClient.PostAsJsonAsync("api/goals", goal);
        }

        public async Task UpdateGoal(int id, Goal goal)
        {
            await _httpClient.PutAsJsonAsync($"api/goals/{id}", goal);
        }

        public async Task DeleteGoal(int id)
        {
            await _httpClient.DeleteAsync($"api/goals/{id}");
        }

        // Ejemplo de uso del modelo Task
        public async Task<List<TaskModel>> GetTasks()
        {
            return await _httpClient.GetFromJsonAsync<List<TaskModel>>("api/tasks");
        }

        public async Task<TaskModel> GetTask(int id)
        {
            return await _httpClient.GetFromJsonAsync<TaskModel>($"api/tasks/{id}");
        }

        public async Task CreateTask(TaskModel task)
        {
            await _httpClient.PostAsJsonAsync("api/tasks", task);
        }

        public async Task UpdateTask(int id, TaskModel task)
        {
            await _httpClient.PutAsJsonAsync($"api/tasks/{id}", task);
        }

        public async Task DeleteTask(int id)
        {
            await _httpClient.DeleteAsync($"api/tasks/{id}");
        }
    }
}
