using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduLiving_Hub.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        public string RecipeName { get; set; }

        public string RecipeType { get; set; }

        public string RecipeDescription { get; set; }
        public string RecipeInstructions { get; set; }
    }

    //Data tranfer Objects(DTO) allows us to package the information for each model

    public class RecipeDto
    {
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public string RecipeType { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeInstructions { get; set; }


    }

}