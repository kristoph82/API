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
    public class OperatorziesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Operatorzies
        public ActionResult Index(string szukanyOperator)
        {
            if (string.IsNullOrEmpty(szukanyOperator))
            {
                return View(db.OperatorzySet.ToList());
            }
            else
            {
                var operatorzies = db.OperatorzySet.Where(o => o.Nazwisko.Contains(szukanyOperator)).OrderBy(o => o.Nazwisko);
                return View(operatorzies.ToList());
            }

        }

        // GET: Operatorzies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.OperatorzySet.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // GET: Operatorzies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operatorzies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imię,Nazwisko,Płaca")] Operatorzy operatorzy)
        {
            if (ModelState.IsValid)
            {
                db.OperatorzySet.Add(operatorzy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operatorzy);
        }

        // GET: Operatorzies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.OperatorzySet.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // POST: Operatorzies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imię,Nazwisko,Płaca")] Operatorzy operatorzy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operatorzy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operatorzy);
        }

        // GET: Operatorzies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.OperatorzySet.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // POST: Operatorzies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operatorzy operatorzy = db.OperatorzySet.Find(id);
            db.OperatorzySet.Remove(operatorzy);
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
