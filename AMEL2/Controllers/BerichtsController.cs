﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMEL2.Models;
using System.IO;
using AMEL2;
using System.Web.Security;

namespace AMEL2.Controllers
{    
    public class BerichtsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private tblAntriebsart TAntriebsart = new tblAntriebsart();
        private PandatasoftEntities1 db1 = new PandatasoftEntities1();
        //Bericht bericht = new Bericht() { };
        // GET: Berichts        
        static string _searchString;

        


        public void ExcelExport_old_ademsr(string sortOrder, string searchString)
        {
            StringWriter sw = new StringWriter();

            //First line for column names
            sw.WriteLine("\"ID\",\"Date\",\"Description\"");

            System.Collections.Generic.List<Bericht> list = getList_admser(sortOrder,  searchString);

            foreach (Bericht item in list)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                           item.Projekt,
                                           item.s1,
                                           item.s2));
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=Abtriebsliste EMSR.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.Write(sw);
            Response.End();
        }

        

        public List<Bericht> getList_admser(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 22 && p.Projekt == 141303);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return bers.ToList();
        }
       

        public ActionResult Index()
        {
            return View(db.Berichts.ToList());
        }
        
        // GET: Berichts



        public ActionResult old_ademsr(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 1 && p.Projekt== 170722);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString) || p.s2.Contains(searchString) || p.s3.Contains(searchString) ||  p.s4.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString) || p.s2.Contains(_searchString) || p.s3.Contains(_searchString) || p.s4.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s4);
                    break;
            }
            ViewBag.TotalAgg = bers.Count();
            return View(bers.ToList());
        }


        public ActionResult old_advmt(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 1 && p.Projekt == 170722);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString) || p.s2.Contains(searchString) || p.s3.Contains(searchString) || p.s4.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString) || p.s2.Contains(_searchString) || p.s3.Contains(_searchString) || p.s4.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s4);
                    break;
            }
            return View(bers.ToList());
        }


        public ActionResult old_ab(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 1 && p.Projekt == 170722);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString) || p.s2.Contains(searchString) || p.s3.Contains(searchString) || p.s4.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString) || p.s2.Contains(_searchString) || p.s3.Contains(_searchString) || p.s4.Contains(_searchString)); 
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s4);
                    break;
            }
            return View(bers.ToList());
        }


        public ActionResult old_mdemsr(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 25 && p.Projekt == 141303);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return View(bers.ToList());
        }


        public ActionResult old_mdvmt(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 26 && p.Projekt == 141303);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return View(bers.ToList());
        }



        public ActionResult old_msb(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 27 && p.Projekt == 141303);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return View(bers.ToList());
        }


        public ActionResult old_msa(string sortOrder, string searchString)
        {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";
            var bers = from s in db.Berichts select s;
            bers = bers.Where(p => p.BN == 28 && p.Projekt == 141303);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }

            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return View(bers.ToList());
        }


        public ActionResult aab(string sortOrder, string searchString)       {
            ViewBag.s1SortParm = String.IsNullOrEmpty(sortOrder) ? "s1_desc" : "";            
            var bers = from s in db.Berichts  select s;
            bers = bers.Where(p => p.BN == 24);
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchString.Equals("All"))
                {
                    _searchString = String.Empty;
                    searchString = String.Empty;
                }
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                _searchString = searchString;
                bers = bers.Where(p => p.s1.Contains(searchString));
            }
            else
            {
                if (!String.IsNullOrEmpty(_searchString))
                {                    
                    bers = bers.Where(p => p.s1.Contains(_searchString));
                }
            }
            
            switch (sortOrder)
            {
                case "s1_desc":
                    bers = bers.OrderByDescending(s => s.s1);
                    break;
            }
            return View(bers.ToList());
        }        
        public ActionResult asa()
        {
            return View(db.Berichts.Where(p => p.BN == 23).ToList());
        }
        public ActionResult agd()
        {
            return View(db.Berichts.Where(p => p.BN == 22).ToList());
        }
        public ActionResult al()
        {
            return View(db.Berichts.Where(p => p.BN == 20).ToList());
        }
        public ActionResult msab()
        {
            return View(db.Berichts.Where(p => p.BN == 19).ToList());
        }
        public ActionResult msgd()
        {
            return View(db.Berichts.Where(p => p.BN == 17).ToList());
        }
        public ActionResult mbr()
        {
            return View(db.Berichts.Where(p => p.BN == 16).ToList());
        }
        public ActionResult msl()
        {
            return View(db.Berichts.Where(p => p.BN == 15).ToList());
        }
        public ActionResult kme()
        {
            return View(db.Berichts.Where(p=>p.BN == 2).ToList());
        }
        public ActionResult zvoss()
        {
            return View(db.Berichts.Where(p => p.BN == 13).ToList());
        }
        // GET: Berichts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }

        // GET: Berichts/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Berichts/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Berichts.Add(bericht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bericht);
        }

        // GET: Berichts/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }

        // POST: Berichts/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        //,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60
        public ActionResult Edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bericht);
        }

        [Authorize(Roles = "canEdit")]
        public ActionResult aabEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]        
        public ActionResult aabEdit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("aab");
            }
            return View(bericht);
        }

        [Authorize(Roles = "canEdit")]
        public ActionResult old_ademsr_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_ademsr_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();                
                BerichtsUpdateTrack but = new BerichtsUpdateTrack() { Projekt = bericht.Projekt, BN = bericht.BN, IT = bericht.IT, Email = User.Identity.Name, Date = DateTime.Now };
                db1.BerichtsUpdateTrack.Add(but);
                db1.SaveChanges();
                return RedirectToAction("old_ademsr");
            }
            return View(bericht);
        }

        [Authorize(Roles = "canEdit")]
        public ActionResult old_advmt_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_advmt_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_advmt");
            }
            return View(bericht);
        }



        [Authorize(Roles = "canEdit")]
        public ActionResult old_ab_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_ab_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_ab");
            }
            return View(bericht);
        }



        [Authorize(Roles = "canEdit")]
        public ActionResult old_mdemsr_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_mdemsr_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_mdemsr");
            }
            return View(bericht);
        }


        [Authorize(Roles = "canEdit")]
        public ActionResult old_mdvmt_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_mdvmt_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_mdvmt");
            }
            return View(bericht);
        }


        [Authorize(Roles = "canEdit")]
        public ActionResult old_msb_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_msb_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_msb");
            }
            return View(bericht);
        }



        [Authorize(Roles = "canEdit")]
        public ActionResult old_msa_edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult old_msa_edit([Bind(Include = "BerichtID,Projekt,BN,IT,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19,s20,s21,s22,s23,s24,s25,s26,s27,s28,s29,s30,s31,s32,s33,s34,s35,s36,s37,s38,s39,s40,s41,s42,s43,s44,s45,s46,s47,s48,s49,s50,s51,s52,s53,s54,s55,s56,s57,s58,s59,s60")] Bericht bericht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bericht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("old_msa");
            }
            return View(bericht);
        }




        // GET: Berichts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bericht bericht = db.Berichts.Find(id);
            if (bericht == null)
            {
                return HttpNotFound();
            }
            return View(bericht);
        }

        // POST: Berichts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bericht bericht = db.Berichts.Find(id);
            db.Berichts.Remove(bericht);
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
