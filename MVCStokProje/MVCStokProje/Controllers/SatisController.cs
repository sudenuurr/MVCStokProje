﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokProje.Models.Entity;
namespace MVCStokProje.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcProjeEntities1 db = new MvcProjeEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATIS p)
        {
            db.TBLSATIS.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}