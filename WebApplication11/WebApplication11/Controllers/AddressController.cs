using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class AddressController : Controller
    {
        private DataDbContext db = new DataDbContext();

        // GET: /Address/
        [ChildActionOnly]
        public ActionResult Index(int id)
        {
            ViewBag.PersonID = id;
            var addresses = db.Addresses.Where(a => a.PersonID == id);

            return PartialView("_Index", addresses.ToList());
        }

        // GET: /Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: /Address/Create
        public ActionResult Create(int PersonID)
        {
            //Address address = new Address();
            //address.PersonID = PersonID;
            var address = db.Addresses.Where(m => m.PersonID == PersonID);
            return PartialView("_Create", address.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,City,Street,Phone,PersonID")] List<Address> address)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in address)
                {
                    db.Addresses.Add(item);
                }               
                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("_Create");
        }

        // GET: /Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "Id", "Name", address.PersonID);
            return PartialView(address);
        }

        // POST: /Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,City,Street,Phone,PersonID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            ViewBag.PersonID = new SelectList(db.People, "Id", "Name", address.PersonID);
            return PartialView(address);
        }

        // GET: /Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return PartialView(address);
        }

        // POST: /Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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
