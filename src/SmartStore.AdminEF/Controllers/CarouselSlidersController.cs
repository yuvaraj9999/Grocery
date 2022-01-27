using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartStore.AdminEF.Entities;

namespace SmartStore.AdminEF.Controllers
{
    public class CarouselSlidersController : Controller
    {
        private GroceryStoreNewEntities db = new GroceryStoreNewEntities();

        // GET: CarouselSliders
        public ActionResult Index()
        {
            return View(db.CarouselSliders.ToList());
        }

        // GET: CarouselSliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselSlider carouselSlider = db.CarouselSliders.Find(id);
            if (carouselSlider == null)
            {
                return HttpNotFound();
            }
            return View(carouselSlider);
        }

        // GET: CarouselSliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarouselSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IName,FilePath,Image,MobileImageFilePath,MobileImage")] CarouselSlider carouselSlider)
        {
            if (ModelState.IsValid)
            {
                db.CarouselSliders.Add(carouselSlider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carouselSlider);
        }

        // GET: CarouselSliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselSlider carouselSlider = db.CarouselSliders.Find(id);
            if (carouselSlider == null)
            {
                return HttpNotFound();
            }
            return View(carouselSlider);
        }

        // POST: CarouselSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IName,FilePath,MobileImageFilePath,MobileImage")] CarouselSlider carouselSlider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                using (Stream fs = Request.Files[0].InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //This line of code is reading the bytes .    
                        carouselSlider.Image = bytes;
                    }
                }
                using (Stream fs = Request.Files[1].InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //This line of code is reading the bytes .    
                        carouselSlider.MobileImage = bytes;
                    }
                }
                db.Entry(carouselSlider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carouselSlider);
        }

        // GET: CarouselSliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarouselSlider carouselSlider = db.CarouselSliders.Find(id);
            if (carouselSlider == null)
            {
                return HttpNotFound();
            }
            return View(carouselSlider);
        }

        // POST: CarouselSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarouselSlider carouselSlider = db.CarouselSliders.Find(id);
            db.CarouselSliders.Remove(carouselSlider);
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
