using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using X.PagedList;

namespace CarMVC.Controllers
{
    public class FuelController : Controller
    {
        private readonly Uri url = new("https://localhost:44318/api/Fuel");
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("");

            // parse the response and return the data.
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<List<FuelVM>>(jsonString);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                responseData = responseData.Where(c => c.Name.Contains(searchString)).ToList();
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            /* if (responseData.Capacity==0)
             {
                 BrandVM brand = new BrandVM();
                 brand.Id = 1;
                 brand.Name="Error";
                 responseData.Add(brand);
             }else*/
            responseData = responseData.ToList();

            return View(responseData.ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Details(int id)
        {

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("Fuel/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<FuelVM>(jsonString);
            return View(responseData);
        }

        // api/fuel/create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FuelVM fuelVM)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(fuelVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("", byteContent);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // api/fuel/edit/id
        public async Task<ActionResult> Edit(int id)
        {

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("fuel/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<FuelVM>(jsonString);
            return View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FuelVM fuelVM)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(fuelVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.PutAsync("fuel/" + fuelVM.Id, byteContent);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // api/fuel/id
        public async Task<ActionResult> Delete(int id)
        {
            using var client = new HttpClient();
            // client.BaseAddress = url;
            // client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.DeleteAsync("Fuel/" + id);
            return View();
            //return RedirectToAction("Index");
        }
    }
}
