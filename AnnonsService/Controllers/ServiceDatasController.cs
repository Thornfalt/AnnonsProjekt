using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnnonsService;
using AnnonsService.Models;

namespace AnnonsService.Controllers
{
    public class ServiceDatasController : Controller
    {
        Authenticator authenticator = new Authenticator();

        private ServiceDBModel db = new ServiceDBModel();

        // GET: ServiceDatas
        public ActionResult Index()
        {
            var serviceData = db.ServiceData.Include(s => s.ServiceModificationsData).Include(s => s.ServiceStatusData).Include(s => s.ServiceTypeData).Include(s => s.SubCategoryData);
            return View(serviceData.ToList());
        }

        // GET: ServiceDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceData serviceData = db.ServiceData.Find(id);
            if (serviceData == null)
            {
                return HttpNotFound();
            }
            return View(serviceData);
        }

        // GET: ServiceDatas/Create
        public ActionResult Create()
        {
            ViewBag.Modified = new SelectList(db.ServiceModificationsData, "Id", "Id");
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatusData, "Id", "Id");
            ViewBag.Type = new SelectList(db.ServiceTypeData, "Id", "Name");
            ViewBag.Category = new SelectList(db.SubCategoryData, "Id", "Titel");
            return View();

        }

        // POST: ServiceDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Category,CreatorID,ServiceStatusID,Picture,CreatedTime,Title,Description,Price,StartDate,EndDate,TimeNeeded,Modified")] ServiceData serviceData)
        {
            if (ModelState.IsValid)
            {
                db.ServiceData.Add(serviceData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Modified = new SelectList(db.ServiceModificationsData, "Id", "Id", serviceData.Modified);
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatusData, "Id", "Id", serviceData.ServiceStatusID);
            ViewBag.Type = new SelectList(db.ServiceTypeData, "Id", "Name", serviceData.Type);
            ViewBag.Category = new SelectList(db.SubCategoryData, "Id", "Titel", serviceData.Category);
            return View(serviceData);
        }

        // GET: ServiceDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceData serviceData = db.ServiceData.Find(id);
            if (serviceData == null)
            {
                return HttpNotFound();
            }

            int serviceCreatorId = serviceData.CreatorID;
            int userId = authenticator.GetUserId();

            if (authenticator.IsAllowed(userId, serviceCreatorId, "EditService"))
            {
                ViewBag.Modified = new SelectList(db.ServiceModificationsData, "Id", "Id", serviceData.Modified);
                ViewBag.ServiceStatusID = new SelectList(db.ServiceStatusData, "Id", "Id", serviceData.ServiceStatusID);
                ViewBag.Type = new SelectList(db.ServiceTypeData, "Id", "Name", serviceData.Type);
                ViewBag.Category = new SelectList(db.SubCategoryData, "Id", "Titel", serviceData.Category);
                return View(serviceData);
            }
            else
            {
                //Obs fixa bättre feedback 
                return HttpNotFound();
                
            }
          
        }

        // POST: ServiceDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Category,CreatorID,ServiceStatusID,Picture,CreatedTime,Title,Description,Price,StartDate,EndDate,TimeNeeded,Modified")] ServiceData serviceData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Modified = new SelectList(db.ServiceModificationsData, "Id", "Id", serviceData.Modified);
            ViewBag.ServiceStatusID = new SelectList(db.ServiceStatusData, "Id", "Id", serviceData.ServiceStatusID);
            ViewBag.Type = new SelectList(db.ServiceTypeData, "Id", "Name", serviceData.Type);
            ViewBag.Category = new SelectList(db.SubCategoryData, "Id", "Titel", serviceData.Category);
            return View(serviceData);
        }

        // GET: ServiceDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceData serviceData = db.ServiceData.Find(id);
            if (serviceData == null)
            {
                return HttpNotFound();
            }
            


            int serviceCreatorId = serviceData.CreatorID;
            int userId = authenticator.GetUserId();

            if (authenticator.IsAllowed(userId, serviceCreatorId, "DeleteService"))
            {
                return View(serviceData);
            }
            else
            {
                //Obs fixa bättre feedback 
                return HttpNotFound();
            }
              
        }

        // POST: ServiceDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceData serviceData = db.ServiceData.Find(id);
            db.ServiceData.Remove(serviceData);
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
