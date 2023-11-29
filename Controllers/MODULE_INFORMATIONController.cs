using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using part3.Models;

namespace part3.Controllers
{
    public class MODULE_INFORMATIONController : Controller
    {
        private MODULE_INFORMATIONEntities1 db = new MODULE_INFORMATIONEntities1();

        // GET: MODULE_INFORMATION
        public ActionResult Index()
        {
            return View(db.MODULE_INFORMATION.ToList());
        }

        // GET: MODULE_INFORMATION/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE_INFORMATION mODULE_INFORMATION = db.MODULE_INFORMATION.Find(id);
            if (mODULE_INFORMATION == null)
            {
                return HttpNotFound();
            }
            return View(mODULE_INFORMATION);
        }

        // GET: MODULE_INFORMATION/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODULE_INFORMATION/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MODULE_CODE,MODUL_NAME,CREDITS,CLASS_HOURS,NUMBER_OF_WEEKS,START_DATE,END_DATE")] MODULE_INFORMATION mODULE_INFORMATION)
        {
            if (ModelState.IsValid)
            {
                // Calculate HOURS_SPENT
                mODULE_INFORMATION.HOURS_SPENT = CalculateHoursSpent(mODULE_INFORMATION.CREDITS, mODULE_INFORMATION.CLASS_HOURS, mODULE_INFORMATION.NUMBER_OF_WEEKS);

                db.MODULE_INFORMATION.Add(mODULE_INFORMATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODULE_INFORMATION);
        }


        // GET: MODULE_INFORMATION/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE_INFORMATION mODULE_INFORMATION = db.MODULE_INFORMATION.Find(id);
            if (mODULE_INFORMATION == null)
            {
                return HttpNotFound();
            }
            return View(mODULE_INFORMATION);
        }

        // POST: MODULE_INFORMATION/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MODULE_CODE,MODUL_NAME,CREDITS,CLASS_HOURS,NUMBER_OF_WEEKS,HOURS_SPENT,START_DATE,END_DATE")] MODULE_INFORMATION mODULE_INFORMATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODULE_INFORMATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODULE_INFORMATION);
        }

        // GET: MODULE_INFORMATION/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE_INFORMATION mODULE_INFORMATION = db.MODULE_INFORMATION.Find(id);
            if (mODULE_INFORMATION == null)
            {
                return HttpNotFound();
            }
            return View(mODULE_INFORMATION);
        }

        // POST: MODULE_INFORMATION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MODULE_INFORMATION mODULE_INFORMATION = db.MODULE_INFORMATION.Find(id);
            db.MODULE_INFORMATION.Remove(mODULE_INFORMATION);
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

        // Add a new method to calculate HOURS_SPENT
        private int CalculateHoursSpent(int credits, int classHours, int numberOfWeeks)
        {
           
            return credits * 10 / numberOfWeeks - classHours;

           
        }
    

            // ... (other actions)

            // POST: MODULE_INFORMATION/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult edit([Bind(Include = "MODULE_CODE,MODUL_NAME,CREDITS,CLASS_HOURS,NUMBER_OF_WEEKS,HOURS_SPENT,PlannedDayOfWeek,START_DATE,END_DATE")] MODULE_INFORMATION mODULE_INFORMATION)
            {
                if (ModelState.IsValid)
                {
                    // Perform calculations for self-study hours
                    mODULE_INFORMATION.HOURS_SPENT = CalculateHoursSpent(mODULE_INFORMATION.CREDITS, mODULE_INFORMATION.CLASS_HOURS, mODULE_INFORMATION.NUMBER_OF_WEEKS);

                    db.MODULE_INFORMATION.Add(mODULE_INFORMATION);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(mODULE_INFORMATION);
            }

            // POST: MODULE_INFORMATION/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult CreatePost([Bind(Include = "MODULE_CODE,MODUL_NAME,CREDITS,CLASS_HOURS,NUMBER_OF_WEEKS,HOURS_SPENT,PlannedDayOfWeek,START_DATE,END_DATE")] MODULE_INFORMATION mODULE_INFORMATION)
            {
                if (ModelState.IsValid)
                {
                    // Perform calculations for self-study hours
                    mODULE_INFORMATION.HOURS_SPENT = CalculateHoursSpent(mODULE_INFORMATION.CREDITS, mODULE_INFORMATION.CLASS_HOURS, mODULE_INFORMATION.NUMBER_OF_WEEKS);

                    db.Entry(mODULE_INFORMATION).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(mODULE_INFORMATION);
            }

            // Display a reminder for the planned module of the day
            public ActionResult DisplayReminder()
            {
                // Get the current day of the week
                DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;

                // Get the module planned for the day
                var plannedModule = db.MODULE_INFORMATION.FirstOrDefault(m => m.PlannedDayOfWeek == (int)currentDayOfWeek);

                if (plannedModule != null)
                {
                    ViewBag.ReminderMessage = $"Today's planned module: {plannedModule.MODUL_NAME}";
                }

                return View();
            }

        }

    }

