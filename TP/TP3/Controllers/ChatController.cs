using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP.Models;

namespace TP3.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> cats;
        public List<Chat> Cats => cats ?? (cats = Chat.GetMeuteDeChats());

        // GET: Chat
        public ActionResult Index()
        {
            var allCats = Cats;

            return View(allCats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var cat = Cats.FirstOrDefault(c => c.Id == id);

            return View(cat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = Cats.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return RedirectToAction("Index");
            }

            return View(cat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var cat = Cats.FirstOrDefault(c => c.Id == id);
                if (cat != null)
                {
                    Cats.Remove(cat);
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
