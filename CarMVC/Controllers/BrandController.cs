using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;
using CarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CarMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly Uri url = new("https://localhost:44318/api/brand");
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
            var responseData = JsonConvert.DeserializeObject<List<BrandVM>>(jsonString);
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
          /* if (responseData==null)
            {
                BrandVM brand = new BrandVM();
                brand.Id = 1;
                brand.Name="Error";
                responseData.Append(brand);
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
            HttpResponseMessage response = await client.GetAsync("Brand/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<BrandVM>(jsonString);
            return View(responseData);
        }

        // api/brand/create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(BrandVM brandVM)
        {
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = JsonConvert.SerializeObject(brandVM);
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
        // api/brand/edit/id
        public async Task<ActionResult> Edit(int id)
        {

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("brand/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<BrandVM>(jsonString);
            return View(responseData);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BrandVM brandVM)
        {
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(brandVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.PutAsync("brand/"+brandVM.Id, byteContent);
                    TempData["message"] = response.StatusCode;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      /*  public async Task<ActionResult> Delete(int id)
        {

            using var client = new HttpClient();
            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // make the request
            HttpResponseMessage response = await client.GetAsync("brand/" + id);

            // parse the response and return data
            string jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<BrandVM>(jsonString);
            return View(responseData);
        }*/
        // api/brand/id
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            // string accessToken = await GetAccessToken();

            /* using var client = new HttpClient();
             client.BaseAddress = url;
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

             // make the request
             HttpResponseMessage response = await client.DeleteAsync("brand/" + brandVM.Id);

             if (response.IsSuccessStatusCode)
             {
                 TempData["result"] = "Записът е премахнат успешно";
             }
             else
             {
                 TempData["result"] = "Записът не беше изтрит";
             }
             // for testing purposes
            //  string jsonString = await response.Content.ReadAsStringAsync();
             // var responseData = JsonConvert.DeserializeObject<BrandVM>(jsonString);
             // return View(responseData);
             return RedirectToAction("Index");*/
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = url;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    // make the request // Save or Update?
                    HttpResponseMessage response = await client.DeleteAsync("brand/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["result"] = "Записът е премахнат успешно";
                    }
                    else
                    {
                        TempData["result"] = "Записът не беше изтрит";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    
    }
}

