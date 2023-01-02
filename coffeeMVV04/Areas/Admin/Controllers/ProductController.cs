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
            CountCategory();
            return View(db.SanPhams.ToList());

        }
        public ActionResult Product()
        {
            CountProduct();
            return View(db.SanPhams.ToList());
        }

        public ActionResult Category()
        {
            CountCategory();
            return View(db.DanhMucs.ToList());
        }
        //View Add Danh Mục 
        public ActionResult Add()
        {
            return View();
        }
        // Đổ dữ liệu từ bảng vào form Edit (EditDanh mục)
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
        //Lấy dữ liệu từ bảng đổ vào from detetedanhmuc
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

        //View AddProduct
        public ActionResult AddProduct()
        {

            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "ID", "TenDanhMuc");
            return View();
        }

        //Lấy dữ liệu từ bảng đổ vào from EditProduct
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }

        //Lấy dữ liệu từ bảng đổ vào from deteteProduct
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }
        //Add Danh mục
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
        //Edit Danh mục
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDanhMuc")] DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }
        //Delete Danh mục
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Add Product
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
                    ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Areas/Admin/img/"), fileName));
                    ojbProduct.Avatar = fileName;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        //Edit Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDanhMuc = new SelectList(db.DanhMucs, "ID", "TenDanhMuc", sanPham.IDDanhMuc);
            return View(sanPham);
        }

        // Delete Product
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Tính số lượng danh mục hiện có
        public void CountCategory()
        {
            if (ModelState.IsValid)
            {
                int count = db.DanhMucs.Count();
                ViewBag.Count = count;
            }
        }

        // Tính số lượng Product hiện có
        public void CountProduct()
        {
            if (ModelState.IsValid)
            {
                int count = db.SanPhams.Count();
                ViewBag.Countt = count;
            }
        }
       
        
    }
    
}