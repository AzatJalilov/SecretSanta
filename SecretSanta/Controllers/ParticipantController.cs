using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecretSanta.Models;

namespace SecretSanta.Controllers
{
    public class ParticipantController : Controller
    {
        private ParticipantContext db = new ParticipantContext();

        // GET: /Participant/
        public ActionResult Index()
        {
            return View(db.ParticipantModels.ToList());
        }

        // GET: /Participant/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParticipantModel participantmodel = db.ParticipantModels.Find(id);
            if (participantmodel == null)
            {
                return HttpNotFound();
            }
            return View(participantmodel);
        }

        // GET: /Participant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Participant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Email,FirstName,LastName")] ParticipantModel participantmodel)
        {
            if (ModelState.IsValid)
            {
                db.ParticipantModels.Add(participantmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(participantmodel);
        }

        //// GET: /Participant/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ParticipantModel participantmodel = db.ParticipantModels.Find(id);
        //    if (participantmodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(participantmodel);
        //}

        //// POST: /Participant/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Email,FirstName,LastName")] ParticipantModel participantmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(participantmodel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(participantmodel);
        //}

        //// GET: /Participant/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ParticipantModel participantmodel = db.ParticipantModels.Find(id);
        //    if (participantmodel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(participantmodel);
        //}

        //// POST: /Participant/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    ParticipantModel participantmodel = db.ParticipantModels.Find(id);
        //    db.ParticipantModels.Remove(participantmodel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
