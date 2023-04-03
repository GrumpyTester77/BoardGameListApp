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
    public class BoardGameTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BoardGameTypes
        public ActionResult Index()
        {
            return View(db.BoardGameTypes.OrderBy(c => c.Type).ToList());
        }

        // GET: BoardGameTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGameType boardGameType = db.BoardGameTypes.Find(id);
            if (boardGameType == null)
            {
                return HttpNotFound();
            }
            return View(boardGameType);
        }

        // GET: BoardGameTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardGameTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] BoardGameType boardGameType)
        {
            if (ModelState.IsValid)
            {
                db.BoardGameTypes.Add(boardGameType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boardGameType);
        }

        // GET: BoardGameTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGameType boardGameType = db.BoardGameTypes.Find(id);
            if (boardGameType == null)
            {
                return HttpNotFound();
            }
            return View(boardGameType);
        }

        // POST: BoardGameTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] BoardGameType boardGameType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardGameType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardGameType);
        }

        // GET: BoardGameTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardGameType boardGameType = db.BoardGameTypes.Find(id);
            if (boardGameType == null)
            {
                return HttpNotFound();
            }
            return View(boardGameType);
        }

        // POST: BoardGameTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardGameType boardGameType = db.BoardGameTypes.Find(id);
            db.BoardGameTypes.Remove(boardGameType);
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
