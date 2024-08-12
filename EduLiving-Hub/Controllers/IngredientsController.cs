using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Mvc;
using EduLiving_Hub.Models;
using EduLiving_Hub.Models.ViewModels;
using System.Web.Script.Serialization;


namespace EduLiving_Hub.Controllers
{
    public class IngredientController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static IngredientController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44391/api/");
        }

        // GET: Ingredients/List
        public ActionResult List()
        {
            string url = "IngredientsData/ListIngredients";
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<IngredientsDto> ingredient = response.Content.ReadAsAsync<IEnumerable<IngredientsDto>>().Result;
                return View(ingredient);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int id)
        {
            DetailsIngredient ViewModel = new DetailsIngredient();

            string url = "IngredientsData/FindIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IngredientsDto selectedIngredient = response.Content.ReadAsAsync<IngredientsDto>().Result;
                ViewModel.SelectedIngredients = selectedIngredient;

                // Additional logic for related data if needed
                // Example: fetch related recipes or other associated data

                return View(ViewModel);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ingredients/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        public ActionResult Create(Ingredients ingredient)
        {
            string url = "IngredientsData/AddIngredient";

            string jsonPayload = jss.Serialize(ingredient);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ingredient/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "IngredientsData/FindIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IngredientsDto selectedIngredient = response.Content.ReadAsAsync<IngredientsDto>().Result;
                return View(selectedIngredient);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Ingredient/Update/5
        [HttpPost]
        public ActionResult Update(int id, Ingredients ingredient)
        {
            string url = "IngredientsData/UpdateIngredient/" + id;

            string jsonPayload = jss.Serialize(ingredient);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Ingredient/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "IngredientsData/FindIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                IngredientsDto selectedIngredient = response.Content.ReadAsAsync<IngredientsDto>().Result;
                return View(selectedIngredient);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Ingredient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "IngredientsData/DeleteIngredient/" + id;
            HttpContent content = new StringContent("");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
