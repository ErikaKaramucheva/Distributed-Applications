using ApplicationService.Implementations;
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
    public class CarController : Controller
    {
        private readonly Uri url = new("https://localhost:44318/api/Car");
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
            var responseData = JsonConvert.DeserializeObject<List<CarVM>>(jsonString);
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
                responseData = responseData.Where(c =>c.Price<=(Int32.Parse(searchString))).ToList();
                responseData.ToList();
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
        public async Task<ActionResult> MyAds(int? page,int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("Car/MyAds/"+id.ToString());

            // parse the response and return the data.
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<List<CarVM>>(jsonString);

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
            HttpResponseMessage response = await client.GetAsync("Car/" + id);
            TempData["id"] = id;
            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CarVM>(jsonString);
            return View(responseData);
        }

        // api/car/create
        public ActionResult Create()
        {
            ModelService ms = new ModelService();
            BrandService bs = new BrandService();
            CarClassService cs = new CarClassService();
            CarStatusService stats = new CarStatusService();
            FuelService fs = new FuelService();
            TransmissionService ts = new TransmissionService();

            var car= new CarVM()
            { Brand = bs.Get(),
              Model=ms.Get(),
            Class=cs.Get(),
            Status=stats.Get(),
            Fuel=fs.Get(),
            Transmission=ts.Get()
            };
            return View(car);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CarVM carVM)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = JsonConvert.SerializeObject(carVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request
                    HttpResponseMessage response = await client.PostAsync("", byteContent);
                   //TempData["res"] = carVM.CreatedBy;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // api/car/edit/id
        public async Task<ActionResult> Edit(int id)
        {
            ModelService ms = new ModelService();
            BrandService bs = new BrandService();
            CarClassService cs = new CarClassService();
            FuelService fs = new FuelService();
            TransmissionService ts = new TransmissionService();
                CarStatusService ss = new CarStatusService();
            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("car/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<CarVM>(jsonString);
            responseData.Brand = bs.Get();
            responseData.Model = ms.Get();
            responseData.Class = cs.Get();
            responseData.Fuel = fs.Get();
            responseData.Status = ss.Get();
            responseData.Transmission = ts.Get();

            return View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CarVM carVM)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var content = JsonConvert.SerializeObject(carVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.PutAsync("car/" + carVM.Id, byteContent);
                    if (response.IsSuccessStatusCode)
                    {
                       // TempData["id"] = "Yes";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // api/car/id
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = url;
             client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.DeleteAsync("car/" + id);
           // return View();
            return RedirectToAction("Index");
        }
    }
}
