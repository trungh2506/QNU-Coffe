
using coffeeMVV04.Areas.Sales.model;
using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coffeeMVV04.Areas.Sales.Controllers
{
    public class HomeSaleController : Controller
    {
        private Model1 db = new Model1();
        // GET: Sales/HomeSale
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.DanhMuc = db.DanhMucs.ToList();
            model.Sanpham = db.SanPhams.ToList();
            return View(model);
        }
        public ActionResult Remove(int numTB, int id)
        {
            string strTb = numTB.ToString();
            //lấy sản phẩm từ session vào card
            Cards cards = (Cards)Session[strTb];
            SanPham sanpham = new SanPham();

            //tìm sản phẩm cần xóa 
            sanpham = laySanpham(id);

            //xóa sản phẩm trong card
            cards.RemoveItem(sanpham);

            //update session
            Session[strTb] = cards;
            return RedirectToAction("Index", new { numTB =  numTB});
        }
        public ActionResult Minus(int numTB, int id)
        {
            string strTb = numTB.ToString();

            //lấy sản phẩm từ session vào card
            Cards cards = (Cards)Session[strTb];
            SanPham sanpham = new SanPham();

            //tìm sản phẩm cần giảm
            sanpham = laySanpham(id);

            int tmp = 0;
            for (int i = 0; i < cards.product.Count; i++)
            {
                if (cards.product[i].SoLuong == 1)
                {
                    cards.RemoveItem(sanpham);
                    Session[strTb] = cards;
                }
                else if (cards.product[i].ID == id)
                {
                    // giảm số lượng đi 1
                    cards.product[i].SoLuong -= 1;
                    // cập nhật session của card
                    Session[strTb] = cards;
                }
               
            }

            return RedirectToAction("Index", new { numTB = numTB });
        }

        /// Thêm sản phẩm vào cart
        public ActionResult addToCart(int numTB, int id)
        {
            string strTb = numTB.ToString();
            Cards cards = (Cards)Session[strTb];
            SanPham sanpham = new SanPham();
            if (cards == null)
            {
                cards = new Cards();
                
                sanpham = laySanpham(id);
                cards.addNewCard(numTB, sanpham);
                Session[strTb] = cards;
            }
            else
            {
                int tmp = 0;
                for(int i = 0; i < cards.product.Count; i++)
                {
                    if(cards.product[i].ID == id)
                    {
                        cards.product[i].SoLuong += 1;
                        tmp++;
                        Session[strTb] = cards;
                        break;
                    }
                    
                    
                }
                if(tmp == 0)
                {
                    sanpham = laySanpham(id);
                    cards.addItem(sanpham);
                    Session[strTb] = cards;
                }
            }
            return RedirectToAction("Index", new { numTB = numTB });

        }
        public SanPham laySanpham(int id)
        {
            SanPham tmp = new SanPham();
            var data = db.SanPhams.Where(s => s.ID.Equals(id)).ToList();
            tmp.ID = data.FirstOrDefault().ID;
            tmp.TenSP = data.FirstOrDefault().TenSP;
            tmp.SoLuong = 1;
            tmp.GiaSP = data.FirstOrDefault().GiaSP;
            tmp.GiamGiaSP = data.FirstOrDefault().GiamGiaSP;
            tmp.IDDanhMuc = data.FirstOrDefault().IDDanhMuc;
            
            return tmp;
        }



    }
}