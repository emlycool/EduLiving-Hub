using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduLiving_Hub.Models
{
    public class RecipeIngredients
    {
        [Key]
        public int Id { get; set; }

        //An ingredients can be used for many recipes
        [ForeignKey("Recipe")]

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }

        //A recipe can have many ingredients
        [ForeignKey("Ingredients")]

        public int IngredientID { get; set; }

        public virtual Ingredients Ingredients { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }


    }
}