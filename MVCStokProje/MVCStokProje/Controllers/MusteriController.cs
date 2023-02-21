using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokProje.Models.Entity;

namespace MVCStokProje.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcProjeEntities1 db = new MvcProjeEntities1();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERİ select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERİ.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİ p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERİ.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERİ.Find(id);
            db.TBLMUSTERİ.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERİ.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBLMUSTERİ p1)
        {
            var mus = db.TBLMUSTERİ.Find(p1.MUSTERIID);
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}