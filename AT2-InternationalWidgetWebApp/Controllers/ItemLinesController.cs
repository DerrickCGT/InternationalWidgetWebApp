using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AT2_InternationalWidgetWebApp.Models;

namespace AT2_InternationalWidgetWebApp.Controllers
{
    public class ItemLinesController : Controller
    {
        private WidgetEntities db = new WidgetEntities();

        // GET: ItemLines
        public ActionResult Index()
        {
            var itemLines = db.ItemLines.Include(i => i.Invoice).Include(i => i.Item);
            return View(itemLines.ToList());
        }

        // GET: ItemLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLine itemLine = db.ItemLines.Find(id);
            if (itemLine == null)
            {
                return HttpNotFound();
            }
            return View(itemLine);
        }

        // GET: ItemLines/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceNo = new SelectList(db.Invoices, "InvoiceNo", "InvoiceNo");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemDescr");
            return View();
        }

        // POST: ItemLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,InvoiceNo,ItemQTY,ItemTotal,TotalPrice")] ItemLine itemLine)
        {
            if (ModelState.IsValid)
            {
                db.ItemLines.Add(itemLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceNo = new SelectList(db.Invoices, "InvoiceNo", "InvoiceNo", itemLine.InvoiceNo);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemDescr", itemLine.ItemID);
            return View(itemLine);
        }

        // GET: ItemLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLine itemLine = db.ItemLines.Find(id);
            if (itemLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceNo = new SelectList(db.Invoices, "InvoiceNo", "InvoiceNo", itemLine.InvoiceNo);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemDescr", itemLine.ItemID);
            return View(itemLine);
        }

        // POST: ItemLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,InvoiceNo,ItemQTY,ItemTotal,TotalPrice")] ItemLine itemLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceNo = new SelectList(db.Invoices, "InvoiceNo", "InvoiceNo", itemLine.InvoiceNo);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemDescr", itemLine.ItemID);
            return View(itemLine);
        }

        // GET: ItemLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemLine itemLine = db.ItemLines.Find(id);
            if (itemLine == null)
            {
                return HttpNotFound();
            }
            return View(itemLine);
        }

        // POST: ItemLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemLine itemLine = db.ItemLines.Find(id);
            db.ItemLines.Remove(itemLine);
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
