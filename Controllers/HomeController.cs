using BoardGameListApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardGameListApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string boardGameType)
        {
            var boardGames = db.BoardGames.Include(b => b.BoardGameType).Include(b => b.Company);

            if (!String.IsNullOrEmpty(boardGameType))
            {
                boardGames = boardGames.Where(p => p.BoardGameType.Type == boardGameType);
            }
            return View(boardGames.ToList());
         }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}