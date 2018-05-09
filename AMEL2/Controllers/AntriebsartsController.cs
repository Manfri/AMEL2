using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace AMEL2.Controllers
{
    public class AntriebsartsController : Controller
    {
        private PandatasoftEntities db = new PandatasoftEntities();
        

        public List<SelectListItem> getListAntriebsart()
        {          
            List<tblAntriebsart> listAntriebsart = db.tblAntriebsart.ToList();            
            var lst = listAntriebsart.Select(x => new SelectListItem { Value = x.Antriebsart.ToString(), Text = x.Antriebsart.ToString() }).ToList();
            return lst;
        }
        // GET: Antriebsarts
        public ActionResult Index()
        {
            
            return View(db.tblAntriebsart.ToList());
        }

        // GET: Antriebsarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAntriebsart tblAntriebsart = db.tblAntriebsart.Find(id);
            if (tblAntriebsart == null)
            {
                return HttpNotFound();
            }
            return View(tblAntriebsart);
        }

        // GET: Antriebsarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Antriebsarts/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Antriebsart")] tblAntriebsart tblAntriebsart)
        {
            if (ModelState.IsValid)
            {
                db.tblAntriebsart.Add(tblAntriebsart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAntriebsart);
        }
        public ActionResult CreateAntrieb()
        {
            if (ModelState.IsValid)
            {
                tblAntriebsart antr = new tblAntriebsart() { Antriebsart = "Test4" };
                db.tblAntriebsart.Add(antr);
                db.SaveChanges();                
            }
            return RedirectToAction("Index");
        }
        
        
        // GET: Antriebsarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAntriebsart tblAntriebsart = db.tblAntriebsart.Find(id);
            if (tblAntriebsart == null)
            {
                return HttpNotFound();
            }
            return View(tblAntriebsart);
        }

        // POST: Antriebsarts/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDAA,Antriebsart")] tblAntriebsart tblAntriebsart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAntriebsart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAntriebsart);
        }

        // GET: Antriebsarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAntriebsart tblAntriebsart = db.tblAntriebsart.Find(id);
            if (tblAntriebsart == null)
            {
                return HttpNotFound();
            }
            return View(tblAntriebsart);
        }

        // POST: Antriebsarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAntriebsart tblAntriebsart = db.tblAntriebsart.Find(id);
            db.tblAntriebsart.Remove(tblAntriebsart);
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
