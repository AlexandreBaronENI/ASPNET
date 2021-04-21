using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace TP3.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats;
        public List<Chat> Chats => chats ?? (chats = Chat.GetMeuteDeChats());

        // GET: Chat
        public ActionResult Index()
        {
            var allCats = Chats;

            return View(allCats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var cat = Chats.FirstOrDefault(c => c.Id == id);

            return View(cat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = Chats.FirstOrDefault(c => c.Id == id);
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
                var chat = Chats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
