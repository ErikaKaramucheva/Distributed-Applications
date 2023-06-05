using ApplicationService.Implementations;
using CarMVC.ExtensionMethods;
using CarMVC.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CarMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Uri url = new("https://localhost:44318/api/Home");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44318/api/User");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync($"User?Username={model.Username}&Password={model.Password}");

            // check response status code
            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("authError", "Невалидни данни!");
                return View(model);
            }

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<List<User>>(jsonString);
            if (responseData == null || responseData.Count == 0)
            {
                ModelState.AddModelError("authError", "Невалидни данни!");
                return View(model);
            }

            User loggedUser=null;
            foreach(var u in responseData)
            {
                if(u.Username==model.Username && u.Password == model.Password)
                {
                    loggedUser = u;
                    break;
                }
            }
            if (loggedUser == null)
            {
                TempData["error"] = "Невалидни данни!";
                return View(model);
            }
            HttpContext.Session.SetObject("loggedUser", loggedUser);
            return RedirectToAction("Index");
        }
        /* public async Task<ActionResult> Login(LoginVM model)
          {
              if (!this.ModelState.IsValid)
                  return View(model);

              using var client = new HttpClient();
              client.BaseAddress = new Uri("https://localhost:44318/api/User");
              client.DefaultRequestHeaders.Accept.Clear();
              client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

              // make the request
             HttpResponseMessage response = await client.GetAsync("User?Username={" + model.Username + "}&Password={" + model.Password + "}");
              // Method = HttpMethod.Get,
              //RequestUri = new Uri(client.BaseAddress, $"Brand?username={username}&password={password}")
              // parse the response and return data
              string jsonString = await response.Content.ReadAsStringAsync();
              var responseData = JsonConvert.DeserializeObject<List<User>>(jsonString);
              if (responseData == null || responseData.Count == 0)
              {
                  this.ModelState.AddModelError("authError", "Невалидни данни!");
                  return View(model);
              }
              User loggedUser = responseData[0];
              HttpContext.Session.SetObject("loggedUser", response);
              return RedirectToAction("Index");
          }*/
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            TownService ts = new TownService();
            var user = new UserVM() { Town = ts.Get() };

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserVM userVM)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:44318/api/User");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(userVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("", byteContent);
                }

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
