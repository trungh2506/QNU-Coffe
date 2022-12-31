using coffeeMVV04.Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coffeeMVV04.Areas.Sales.model
{
    public class Cards
    {
        private int NumTable;
        private List<SanPham> Product = new List<SanPham>();
        public Cards()
        {


        }
        public void addNewCard(int ntb,SanPham pd)
        {
            this.NumTable = ntb;
            this.Product.Add(new SanPham { ID = pd.ID, TenSP = pd.TenSP, SoLuong = 1, GiaSP = pd.GiaSP, GiamGiaSP = pd.GiamGiaSP, IDDanhMuc = pd.IDDanhMuc });
        }
        public void addItem(SanPham pd)
        {
            this.Product.Add(new SanPham { ID = pd.ID, TenSP = pd.TenSP, SoLuong = 1, GiaSP = pd.GiaSP, GiamGiaSP = pd.GiamGiaSP, IDDanhMuc = pd.IDDanhMuc });

        }
        public void addQTT(SanPham pd)
        {
            
        }
        public void RemoveItem(SanPham pd)
        {
            int index = Product.Select(T => T.ID).ToList().IndexOf(pd.ID);
            Product.RemoveAt(index);
        }
        public int getCounlist()
        {
            return product.Count;
        }

        public int numTable { get => NumTable; set => NumTable = value; }
        public List<SanPham> product { get => Product; set => Product = value; }

        public int Total()
        {
            int total = 0;
            for (int i = 0; i < Product.Count(); i++)
            {
                total += (int)(Product[i].GiaSP* Product[i].SoLuong);
            }
            return total;
        }
    }
}