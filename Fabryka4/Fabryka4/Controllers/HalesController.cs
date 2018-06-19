using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fabryka4;

namespace Fabryka4.Controllers
{
    public class HalesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Hales
        public ActionResult Index(string szukanaHala)
        {
            if (string.IsNullOrEmpty(szukanaHala))
            {
                return View(db.HaleSet.ToList());
            }
            else
            {
                var hales = db.HaleSet.Where(h => h.Nazwa.Contains(szukanaHala)).OrderBy(h => h.Nazwa);
                return View(hales.ToList());
            }
        }
        

        // GET: Hales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.HaleSet.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // GET: Hales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Adres")] Hale hale)
        {
            if (ModelState.IsValid)
            {
                db.HaleSet.Add(hale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hale);
        }

        // GET: Hales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.HaleSet.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // POST: Hales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Adres")] Hale hale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hale);
        }

        // GET: Hales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.HaleSet.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // POST: Hales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hale hale = db.HaleSet.Find(id);
            db.HaleSet.Remove(hale);
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
