using BO;
using System.Web.Mvc;

namespace TP4.Models.ViewModels
{
    public class PizzaViewModel : Controller
    {
        public SelectList ListePates { get; set; }
        public MultiSelectList ListeIngredients { get; set; }
        public int[] ListeIdIngredientsSelected { get; set; }
        public int PateIdSelected { get; set; }
        public Pizza Pizza { get; set; }
    }
}