using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokProje.Models.Entity;

namespace MVCStokProje.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcProjeEntities1 db = new MvcProjeEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLURUN.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİ.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUN p1)
        {
            var ktg = db.TBLKATEGORİ.Where(m => m.KATEGORIID == p1.TBLKATEGORİ.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORİ = ktg;
            db.TBLURUN.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUN.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİ.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBLURUN p)
        {
            var urun = db.TBLURUN.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            urun.MARKA = p.MARKA;
            urun.STOK = p.STOK;
            urun.FİYAT = p.FİYAT;
            var ktg = db.TBLKATEGORİ.Where(m => m.KATEGORIID == p.TBLKATEGORİ.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}