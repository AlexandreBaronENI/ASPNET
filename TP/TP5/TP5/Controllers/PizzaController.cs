using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP5.Models.ViewModels;

namespace TP5.Controllers
{
    public class PizzaController : Controller
    {
        public static List<Pizza> Pizzas = new List<Pizza>()
        {
            new Pizza()
            {
                Id = 1,
                Ingredients = Pizza.IngredientsDisponibles.GetRange(1, 5),
                Nom = "Pizza 1",
                Pate = Pizza.PatesDisponibles[0]
            },
            new Pizza()
            {
                Id = 2,
                Ingredients = Pizza.IngredientsDisponibles.GetRange(3, 5),
                Nom = "Pizza 2",
                Pate = Pizza.PatesDisponibles[2]
            },
        };

        // GET: Pizza
        public ActionResult Index()
        {
            return View(Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
                return RedirectToAction("Index");
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            var vm = new PizzaViewModel()
            {
                ListePates = new SelectList(GetPates(), "Value", "Text"),
                ListeIngredients = new MultiSelectList(GetIngredients(), "Value", "Text"),
                Pizza = new Pizza()
            };

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                var pizza = vm.Pizza;

                if (Pizzas.FirstOrDefault(p => String.Equals(p.Nom, vm.Pizza.Nom, StringComparison.OrdinalIgnoreCase)) != null)
                    ModelState.AddModelError("ErrorNomPizza", "Une pizza avec ce nom existe déjà");

                pizza.Id = Pizzas.Count > 0 ? Pizzas.Max(p => p.Id) + 1 : 1;
                
                if (vm.PateIdSelected == null)
                    ModelState.AddModelError("ErrorPate", "Merci de selectionner une pate");

                var pate = Pizza.PatesDisponibles.FirstOrDefault(p => p.Id == vm.PateIdSelected);
                if (pate != null)
                    pizza.Pate = pate;

                if (vm.ListeIdIngredientsSelected == null || vm.ListeIdIngredientsSelected.Length < 2 || vm.ListeIdIngredientsSelected.Length > 5)
                    ModelState.AddModelError("ErrorIngredients", "Merci de selectionner entre 2 et 5 ingrédients");

                foreach (var id in vm.ListeIdIngredientsSelected)
                {
                    var ingredient = Pizza.IngredientsDisponibles.FirstOrDefault(p => p.Id == id);
                    if (ingredient != null)
                        pizza.Ingredients.Add(ingredient);
                }

                foreach (var pizzaTemp in Pizzas)
                {
                    var intersect = pizza.Ingredients.OrderBy(i => i.Id).Select(i => i.Id).Intersect(pizzaTemp.Ingredients.OrderBy(i => i.Id).Select(i => i.Id)).ToList();

                    if (pizza.Ingredients.Count == pizzaTemp.Ingredients.Count && intersect.Count == pizza.Ingredients.Count)
                        ModelState.AddModelError("ErrorListeIngredients", "Une pizza avec ces ingrédients existent déjà");
                }


                if (ModelState.IsValid)
                {
                    Pizzas.Add(pizza);
                }
                else
                {

                    vm.ListePates = new SelectList(GetPates(), "Value", "Text");
                    vm.ListeIngredients = new MultiSelectList(GetIngredients(), "Value", "Text");
                    return View(vm);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if( pizza == null)
                return RedirectToAction("Index");

            var pates = Pizza.PatesDisponibles.Select(a => new SelectListItem
            {
                Text = a.Nom,
                Value = a.Id.ToString()
            });
            var ingredients = Pizza.IngredientsDisponibles.Select(a => new SelectListItem
            {
                Text = a.Nom,
                Value = a.Id.ToString()
            });

            var vm = new PizzaViewModel()
            {
                ListePates = new SelectList(pates, "Value", "Text", pizza.Pate),
                ListeIngredients = new MultiSelectList(ingredients, "Value", "Text", null, pizza.Ingredients.Select(p => p.Id)),
                Pizza = pizza,
                PateIdSelected = pizza.Pate.Id
            };

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, PizzaViewModel vm)
        {
            try
            {
                // TODO: Add update logic here
                var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
                if (Pizzas.FirstOrDefault(p => p.Id == id) == null)
                    return RedirectToAction("Index");

                var pate = Pizza.PatesDisponibles.FirstOrDefault(p => p.Id == vm.PateIdSelected);
                if (pate != null)
                    pizza.Pate = pate;

                pizza.Ingredients = new List<Ingredient>();
                foreach (var idIngredient in vm.ListeIdIngredientsSelected)
                {
                    var ingredient = Pizza.IngredientsDisponibles.FirstOrDefault(p => p.Id == idIngredient);
                    if (ingredient != null)
                        pizza.Ingredients.Add(ingredient);
                }

                var index = Pizzas.FindIndex(p => p.Id == id);

                Pizzas[index] = pizza;

                return RedirectToAction("Index");
            }
            catch
            {
                vm.ListePates = new SelectList(GetPates(), "Value", "Text");
                vm.ListeIngredients = new MultiSelectList(GetIngredients(), "Value", "Text");
                return View(vm);
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            if (pizza == null)
                return RedirectToAction("Index");
            var vm = new PizzaViewModel()
            {
                Pizza = pizza
            };
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizza == null)
                    return RedirectToAction("Index");
                Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> GetIngredients()
        {
            return Pizza.IngredientsDisponibles.Select(a => new SelectListItem
            {
                Text = a.Nom,
                Value = a.Id.ToString()
            });
        }

        private IEnumerable<SelectListItem> GetPates()
        {
            return Pizza.PatesDisponibles.Select(a => new SelectListItem
            {
                Text = a.Nom,
                Value = a.Id.ToString()
            });
        }
    }
}
