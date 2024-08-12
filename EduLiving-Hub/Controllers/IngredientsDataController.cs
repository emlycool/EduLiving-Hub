using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using EduLiving_Hub.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Diagnostics;



public class IngredientsDataController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Lists the recipe details in the database

        /// </summary>
        /// <returns> An array of recipe objects dtos/returns>
        /// <example>
        /// <returns></returns>
        //GET: api/IngredientsData/ListIngredients->
        ///</example>
        [HttpGet]
        [Route("api/IngredientsData/ListIngredients")]
        public List<IngredientsDto> ListIngredients()
        {
            //SELECT * FROM RECIPE
            List<Ingredients> IngredientData = db.Ingredient.ToList();

            List<IngredientsDto> IngredientsDtos = new List<IngredientsDto>();

            foreach (Ingredients Ingredients in IngredientData)
            {
                IngredientsDto Dto = new IngredientsDto();

                Dto.IngredientID = Ingredients.IngredientID;
                Dto.IngredientName = Ingredients.IngredientName;


                IngredientsDtos.Add(Dto);


            }
            return IngredientsDtos;

        }


        /// <summary>
        /// Retrieves a specific recipe by its ID.
        /// </summary>
        /// <param name="id">The ID of the recipe to retrieve.</param>
        /// <returns>A recipe DTO if found, NotFound if not found.</returns>
        /// <example>
        /// GET: api/IngredientsData/FindIngredient/2
        /// </example>


        [ResponseType(typeof(Ingredients))]
        [HttpGet]
        public IHttpActionResult FindIngredient(int id)
        {
            Ingredients Ingredients = db.Ingredient.Find(id);
            IngredientsDto IngredientsDto = new IngredientsDto()
            {
                IngredientID = Ingredients.IngredientID,
                IngredientName = Ingredients.IngredientName

            };
            if (Ingredients == null)
            {
                return NotFound();
            }

            return Ok(IngredientsDto);
        }


        /// <summary>
        /// Adds a new recipe to the database.
        /// </summary>
        /// <param name="recipe">The recipe object to add.</param>
        /// <returns>OK if successful, BadRequest if the model state is invalid.</returns>
        /// <example>
        /// POST: api/IngredientsData/AddIngredient
        /// </example>


        [ResponseType(typeof(Ingredients))]
        [HttpPost]
        public IHttpActionResult AddIngredient(Ingredients ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ingredient.Add(ingredient);
            db.SaveChanges();

            return Ok();
        }


        /// <summary>
        /// Deletes a recipe from the database.
        /// </summary>
        /// <param name="id">The ID of the recipe to delete.</param>
        /// <returns>OK if successful, NotFound if the recipe doesn't exist.</returns>
        /// <example>
        /// POST: api/IngredientData/DeleteRecipe/2
        /// </example>


        [ResponseType(typeof(Ingredients))]
        [HttpPost]
        public IHttpActionResult DeleteIngredient(int id)
        {
            Ingredients ingredient = db.Ingredient.Find(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            db.Ingredient.Remove(ingredient);
            db.SaveChanges();

            return Ok();
        }

    }



