using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP4.Models.ViewModels;

namespace TP4.Controllers
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
                ListePates = new SelectList(pates, "Value", "Text"),
                ListeIngredients = new MultiSelectList(ingredients, "Value", "Text"),
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
                // TODO: Add insert logic here
                if (!String.IsNullOrEmpty(vm.Pizza.Nom))
                {
                    var pizza = vm.Pizza;

                    pizza.Id = Pizzas.Count > 0 ? Pizzas.Max(p => p.Id) + 1 : 1;
                    var pate = Pizza.PatesDisponibles.FirstOrDefault(p => p.Id == vm.PateIdSelected);
                    if (pate != null)
                        pizza.Pate = pate;

                    foreach (var id in vm.ListeIdIngredientsSelected)
                    {
                        var ingredient = Pizza.IngredientsDisponibles.FirstOrDefault(p => p.Id == id);
                        if (ingredient != null)
                            pizza.Ingredients.Add(ingredient);
                    }

                    Pizzas.Add(pizza);
                }

                return RedirectToAction("Index");
            }
            catch
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
    }
}
