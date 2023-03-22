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
    }
}
