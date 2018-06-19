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
    public class MaszyniesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Maszynies
        public ActionResult Index(string szukanaMaszyna)
        {
            if (string.IsNullOrEmpty(szukanaMaszyna))
            {
                var maszynies = db.MaszynySet.Include(m => m.Hale).OrderBy(m => m.Nazwa);
                return View(maszynies.ToList());
            }
            else
            {
                var maszynies = db.MaszynySet.Include(m => m.Hale).Where(m => m.Nazwa.Contains(szukanaMaszyna)).OrderBy(m => m.Nazwa);
                return View(maszynies.ToList());
            }
        }

        // GET: Maszynies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.MaszynySet.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            return View(maszyny);
        }

        // GET: Maszynies/Create
        public ActionResult Create()
        {
            ViewBag.HaleId = new SelectList(db.HaleSet, "Id", "Nazwa");
            return View();
        }

        // POST: Maszynies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Data_ur,HaleId")] Maszyny maszyny)
        {
            if (ModelState.IsValid)
            {
                db.MaszynySet.Add(maszyny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HaleId = new SelectList(db.HaleSet, "Id", "Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // GET: Maszynies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.MaszynySet.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            ViewBag.HaleId = new SelectList(db.HaleSet, "Id", "Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // POST: Maszynies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Data_ur,HaleId")] Maszyny maszyny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maszyny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HaleId = new SelectList(db.HaleSet, "Id", "Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // GET: Maszynies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.MaszynySet.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            return View(maszyny);
        }

        // POST: Maszynies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maszyny maszyny = db.MaszynySet.Find(id);
            db.MaszynySet.Remove(maszyny);
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
