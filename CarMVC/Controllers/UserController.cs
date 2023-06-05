using ApplicationService.Implementations;
using CarMVC.ExtensionMethods;
using CarMVC.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CarMVC.Controllers
{
    [AuthenticationFilter]
    public class UserController : Controller
    {
        private readonly Uri url = new("https://localhost:44318/api/User");
       

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "User");
        }

        //my profile
        public async Task<ActionResult> Details(int id)
        {

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            TempData["id"] = id;
            // make the request
            HttpResponseMessage response = await client.GetAsync("User/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<UserVM>(jsonString);
            return View(responseData);
        }

        // api/user/register
        public ActionResult Register()
        {
            TownService ts = new TownService();
            var user = new UserVM() {Town=ts.Get() };

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserVM userVM)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(userVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("", byteContent);
                }

                return RedirectToAction("Home/Index");
            }
            catch
            {
                return View();
            }
        }
        // api/user/edit/id
        public async Task<ActionResult> Edit(int id)
        {
            TownService ts = new TownService();

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            // make the request
            HttpResponseMessage response = await client.GetAsync("user/" + id);
            //TempData["message"] =id;
            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<UserVM>(jsonString);
            responseData.Town = ts.Get();
            return View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserVM userVM)
        { try
             {
                 var userId = userVM.Id;
                 using (var client = new HttpClient())
                 {
                     client.BaseAddress = url;
                     client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                     var content = JsonConvert.SerializeObject(userVM);
                     var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                     var byteContent = new ByteArrayContent(buffer);
                     byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                     // make the request // Save or Update?
                     HttpResponseMessage response = await client.PutAsync("user/" + userId, byteContent);

                 }
                 return RedirectToAction("Index" ,"Home") ;
             }
             catch
             {
                 return View();
             }
        }

        // api/user/id
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // make the request
                HttpResponseMessage response = await client.DeleteAsync("user/" + id);

                // for testing purposes
                // string jsonString = await response.Content.ReadAsStringAsync();
                // var responseData = JsonConvert.DeserializeObject<NationalityViewModel>(jsonString);
                // return View(responseData);
                return RedirectToAction("Index");
            }
        }
    }
}
