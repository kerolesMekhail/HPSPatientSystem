using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patient_Systems.Models;
using System.IO;
using Rotativa.MVC;

namespace Patient_Systems.Controllers
{
    [Authorize(Roles = "employee")]

    public class Patient_DataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patient_Data
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var data = db.PatientData.SqlQuery("[dbo].[Get_ALL_Patient_Data]").ToList();
                return View(data);
            }

        }
        // GET: Patient_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Data patient_Data = db.PatientData.Find(id);
            if (patient_Data == null)
            {
                return HttpNotFound();
            }
            return View(patient_Data);
        }
        public ActionResult PrintOne()
        {
            var p = new ActionAsPdf("Details");
            return p;
        }
        // GET: Patient_Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient_Data patient_Data)
        {

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(patient_Data.ImageFile.FileName);
                string extension = Path.GetExtension(patient_Data.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                patient_Data.Image = "~/Content/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                patient_Data.ImageFile.SaveAs(fileName);
                db.PatientData.Add(patient_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        // GET: Patient_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Data patient_Data = db.PatientData.Find(id);
            if (patient_Data == null)
            {
                return HttpNotFound();
            }
            return View(patient_Data);
        }

        // POST: Patient_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Full_Name,Address,Age,Gender,Mobile,Image")] Patient_Data patient_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient_Data);
        }

        // GET: Patient_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient_Data patient_Data = db.PatientData.Find(id);
            if (patient_Data == null)
            {
                return HttpNotFound();
            }
            return View(patient_Data);
        }

        // POST: Patient_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient_Data patient_Data = db.PatientData.Find(id);
            db.PatientData.Remove(patient_Data);
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
