using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLabs.Models;
using System.IO;
using MVCLabs.Models;

namespace MVCLabs.Controllers
{
    public class ImageModellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ImageModells
        public ActionResult Index()
        {
            var Image = new List<ImageModell>();
            var images = Directory.GetFiles(Server.MapPath("/Uploads"));

            foreach (var img in images)
            {
                var info = new FileInfo(img);

                Image.Add(new ImageModell
                {

                    ID = Guid.NewGuid(),
                    Name = info.Name
                });
            }
            return View(Image);
        }

        // GET: ImageModells/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModell imageModell = db.ImageModells.Find(id);
            if (imageModell == null)
            {
                return HttpNotFound();
            }
            return View(imageModell);
        }

        // GET: ImageModells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageModells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageModell image, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                return View(image);
            }
            if (file == null)
            {
                ModelState.AddModelError("Error", "No choosen file");
                return View(image);
            }
            file.SaveAs(Path.Combine(Server.MapPath("/Uploads")));
            return RedirectToAction("Index");
        }

        // GET: ImageModells/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModell imageModell = db.ImageModells.Find(id);
            if (imageModell == null)
            {
                return HttpNotFound();
            }
            return View(imageModell);
        }

        // POST: ImageModells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] ImageModell imageModell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageModell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageModell);
        }

        // GET: ImageModells/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageModell imageModell = db.ImageModells.Find(id);
            if (imageModell == null)
            {
                return HttpNotFound();
            }
            return View(imageModell);
        }

        // POST: ImageModells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ImageModell imageModell = db.ImageModells.Find(id);
            db.ImageModells.Remove(imageModell);
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
