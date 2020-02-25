using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoomManage.Models;
using Microsoft.AspNet.Identity;

namespace RoomManage.Controllers
{
    [Authorize]
    public class BarrennessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Barrennesses
        public ActionResult Index()
        {
       var UserId = User.Identity.GetUserId();
            var barrennesses = db.Barrennesses.Where(a => a.UserId == UserId ).Include(b => b.Category);
            return View(barrennesses.ToList());
        }

        // GET: Barrennesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrenness barrenness = db.Barrennesses.Find(id);
            if (barrenness == null)
            {
                return HttpNotFound();
            }
            return View(barrenness);
        }

        // GET: Barrennesses/Create
        public ActionResult Create()
        {
            if (Session["language"] != null && Session["language"].ToString() == "ar")
            {
                ViewBag.PaymentMethod = new SelectList(new[] { "يومي", "شهري", "سنوي", "بيع" });
                ViewBag.State = new SelectList(new[] { "الجزيرة", "الخرطوم", "سنار", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" });
            }
            else
            {
                ViewBag.PaymentMethod = new SelectList(new[] { "daily", "monthy", "years", "buy" });
                ViewBag.State = new SelectList(new[] { "gazera", "khartoom", "senar", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" });
            }
           
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle");
          

            return View();
        }

        // POST: Barrennesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Barrenness barrenness)
        {
            if (ModelState.IsValid)
            {
               barrenness.UserId = User.Identity.GetUserId();
                barrenness.publishDate = DateTime.Now;
                db.Barrennesses.Add(barrenness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaymentMethod = new SelectList(new[] { "يومي", "شهري", "سنوي", "بيع" });
            ViewBag.State = new SelectList(new[] { "الجزيرة", "الخرطوم", "سنار", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" });
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", barrenness.CategoryId);
            return View(barrenness);
        }

        // GET: Barrennesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrenness barrenness = db.Barrennesses.Find(id);
            if (barrenness == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaymentMethod = new SelectList(new[] { "يومي", "شهري", "سنوي", "بيع" } ,barrenness.paymentMethod);
            ViewBag.State = new SelectList(new[] { "الجزيرة", "الخرطوم", "سنار", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" } ,barrenness.state);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", barrenness.CategoryId);
            return View(barrenness);
        }

        // POST: Barrennesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,barrenessDescription,CategoryId,leasePrice,paymentMethod,Number ,publishDate,state,fullLocation,status")] Barrenness barrenness)
        {
            if (ModelState.IsValid)
            {
                barrenness.publishDate = DateTime.Now;
                barrenness.UserId = User.Identity.GetUserId();
                db.Entry(barrenness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaymentMethod = new SelectList(new[] { "يومي", "شهري", "سنوي", "بيع" }, barrenness.paymentMethod);
            ViewBag.State = new SelectList(new[] { "الجزيرة", "الخرطوم", "سنار", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" }, barrenness.state);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle", barrenness.CategoryId);
            return View(barrenness);
        }

        // GET: Barrennesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrenness barrenness = db.Barrennesses.Find(id);
            if (barrenness == null)
            {
                return HttpNotFound();
            }
            return View(barrenness);
        }

        // POST: Barrennesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrenness barrenness = db.Barrennesses.Find(id);
            db.Barrennesses.Remove(barrenness);
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
