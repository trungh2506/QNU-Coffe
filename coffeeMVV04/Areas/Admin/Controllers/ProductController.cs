using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coffeeMVC05.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Product
        public ActionResult Index()
        {
            CountProduct();
            return View(db.SanPhams.ToList());

        }
        /*public ActionResult Edit()
        {
            return View();
        }*/
        public ActionResult EditProduct()
        {
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }
        public ActionResult DeleteProduct()
        {
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }
        public ActionResult Product()
        {
            CountProduct();
            return View(db.SanPhams.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Category()
        {
            CountCategory();
            return View(db.DanhMucs.ToList());
        }
        public ActionResult AddProduct()
        {
            
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "ID", "TenDanhMuc");
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "TenDanhMuc")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danhMuc);
        }
        public void CountCategory()
        {
            if (ModelState.IsValid)
            {
                int count = db.DanhMucs.Count();
                ViewBag.Count = count;
            }
        }
        public void CountProduct()
        {
            if (ModelState.IsValid)
            {
                int count = db.SanPhams.Count();
                ViewBag.Count = count;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="ID,TenDanhMuc")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }
    
        [HttpPost]
        public ActionResult AddProduct(SanPham ojbProduct, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(ojbProduct);
                if (ImageUpload != null)
                    {
                        string fileName = "";
                        fileName = ImageUpload.FileName;
                        //string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                        //string extension = Path.GetExtension(ImageUpload.FileName);
                        //fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss") + extension);
                        //fileName = (fileName + "." + extension);
                        ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Areas/Admin/img/"), fileName));
                        ojbProduct.Avatar = fileName;
                        db.SaveChanges();
                    }
            }
            return RedirectToAction("Index");
        }
    }
    
}