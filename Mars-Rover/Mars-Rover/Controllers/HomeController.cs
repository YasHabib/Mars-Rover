using Mars_Rover.Models;
using Mars_Rover.Models.Entities;
using Mars_Rover.Models.Objects;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
namespace Mars_Rover.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoverFrontendServices _roverFrontendServices;
        public const string BasePath = "http://localhost:2000";
        //public const string BasePath = "http://host.docker.internal:2000\r\n";



        public HomeController(ILogger<HomeController> logger, IRoverFrontendServices roverFrontendServices)
        {
            _logger = logger;
            _roverFrontendServices = roverFrontendServices;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }

        public async Task<IActionResult> History()
        {
            //TO remove SSL certificate error
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient
            HttpClient client = new HttpClient(clientHandler, false);


            DataTable dt = new DataTable();

            //var history = await _roverFrontendServices.ViewRoverHistory();
            //return View(history);
            using (client)
            {
                client.BaseAddress = new Uri(BasePath);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getRoverData = await client.GetAsync("/api/Rover/rover-history");
                if (getRoverData.IsSuccessStatusCode)
                {
                    string results = getRoverData.Content.ReadAsStringAsync().Result;
                    dt =JsonConvert.DeserializeObject<DataTable>(results);
                }
                else
                {
                    throw new Exception("There was an error getting the rover data");
                }

                ViewData.Model = dt;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}