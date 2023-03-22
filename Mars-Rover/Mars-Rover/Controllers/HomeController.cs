﻿using Mars_Rover.Models;
using Mars_Rover.Models.Entities;
using Mars_Rover.Models.FrontendViewModels;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.Base;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Dynamic;

namespace Mars_Rover.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoverFrontendServices _roverFrontendServices;
        public const string BasePath = "http://localhost:2000";



        public HomeController(ILogger<HomeController> logger, IRoverFrontendServices roverFrontendServices)
        {
            _logger = logger;
            _roverFrontendServices = roverFrontendServices;
        }


        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            //To remove SSL certificate error
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient
            HttpClient client = new HttpClient(clientHandler, false);

            //Getting list of rovers
            List<RoverViewModel> rovers = new List<RoverViewModel>();

            //Getting inputs based on selected rover
            //List<RoverInputsViewModel> roverInputs = new List<RoverInputsViewModel>();

            using (client)
            {
                client.BaseAddress = new Uri(BasePath);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Rover list
                HttpResponseMessage getRovers = await client.GetAsync("/api/Rover/rovers");
                if (getRovers.IsSuccessStatusCode)
                {
                    string results = getRovers.Content.ReadAsStringAsync().Result;
                    rovers = JsonConvert.DeserializeObject<List<RoverViewModel>>(results);
                }
                else
                {
                    throw new Exception("There was an error getting the rover data");
                }
                ViewData["RoverVM"] = rovers;

                ////Input lists based on selected rover
                //HttpResponseMessage displayRoverInputs = await client.GetAsync("/api/Rover/input-fields");
                //if (getRovers.IsSuccessStatusCode)
                //{
                //    string response = displayRoverInputs.Content.ReadAsStringAsync().Result;
                //    roverInputs = JsonConvert.DeserializeObject<List<RoverInputsViewModel>>(response);
                //}
                //else
                //{
                //    throw new Exception("There was an error getting the rover data");
                //}
                //ViewData["RoverInputVM"] = roverInputs;
            }

            return View();
        }

        //[HttpGet]
        public async Task<IActionResult> History()
        {
            //To remove SSL certificate error
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient
            HttpClient client = new HttpClient(clientHandler, false);

            DataTable dt = new DataTable();

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