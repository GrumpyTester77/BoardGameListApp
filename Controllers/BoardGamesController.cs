using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoardGameListApp.Models;

namespace BoardGameListApp.Controllers
{
    public class BoardGamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BoardGames
        public ActionResult Index(string boardGameType)
        {
            var boardGames = db.BoardGames.Include(b => b.BoardGameType).Include(b => b.Company);

            if (!String.IsNullOrEmpty(boardGameType))
            {
                boardGames = boardGames.Where(p => p.BoardGameType.Type == boardGameType);
            }
            return View(boardGames.ToList());
        }

        // GET: BoardGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // GET: BoardGames/Create
        public ActionResult Create()
        {
            ViewBag.BoardGameTypeId = new SelectList(db.BoardGameTypes, "ID", "Type");
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: BoardGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,CompanyID,BoardGameTypeId")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.BoardGames.Add(boardGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoardGameTypeId = new SelectList(db.BoardGameTypes, "ID", "Type", boardGame.BoardGameTypeId);
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", boardGame.CompanyID);
            return View(boardGame);
        }

        // GET: BoardGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoardGameTypeId = new SelectList(db.BoardGameTypes, "ID", "Type", boardGame.BoardGameTypeId);
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", boardGame.CompanyID);
            return View(boardGame);
        }

        // POST: BoardGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,CompanyID,BoardGameTypeId")] BoardGame boardGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoardGameTypeId = new SelectList(db.BoardGameTypes, "ID", "Type", boardGame.BoardGameTypeId);
            ViewBag.CompanyID = new SelectList(db.Companies, "ID", "Name", boardGame.CompanyID);
            return View(boardGame);
        }

        // GET: BoardGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGame boardGame = db.BoardGames.Find(id);
            if (boardGame == null)
            {
                return HttpNotFound();
            }
            return View(boardGame);
        }

        // POST: BoardGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            db.BoardGames.Remove(boardGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
