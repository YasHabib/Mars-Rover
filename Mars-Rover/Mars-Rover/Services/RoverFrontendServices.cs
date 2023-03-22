using Mars_Rover.Helpers;
using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Services.Interfaces;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Mars_Rover.Services
{
    public class RoverFrontendServices : IRoverFrontendServices
    {

        private readonly HttpClient _httpClient;

        public const string BasePath = "https://localhost:2000";

        public RoverFrontendServices(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public Task<List<RoverHistoryViewModel>> ViewRoverHistory()
        {
            //_httpClient.BaseAddress = new Uri(BasePath + "/api/Rover/rover-history");
            //_httpClient.DefaultRequestHeaders.Accept.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(
            //    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //_positions = new List<RoverHistoryViewModel>();
            //using (var httpClient = new HttpClient(_httpClientHandler))
            //{
            //    using (var response = await httpClient.GetAsync(BasePath + "/api/Rover/rover-history"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        _positions = JsonConvert.DeserializeObject<List<RoverHistoryViewModel>>(apiResponse);
            //    }
            //}
            //return _positions;
            throw new NotImplementedException();
        }
        //public async Task<List<RoverHistoryViewModel>> ViewRoverHistory()
        //{
        //    var response = await _httpClient.GetAsync("/api/Rover/rover-history");

        //    return await response.ReadContentAsync<List<RoverHistoryViewModel>>();
        //}
    }
}
