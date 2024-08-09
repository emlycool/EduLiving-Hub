using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace EduLiving_Hub.Models
{
    public class Ingredients
    {

        [Key]
        public int IngredientID { get; set; }

        public string IngredientName { get; set; }
    }

    public class IngredientsDto
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
    }
}