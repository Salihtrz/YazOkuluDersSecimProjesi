using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntiyLayer;
using DataAccesLayer;
using BusinessLogicLayer;

namespace YazOkuluDersler
{
    public partial class Kontenjanlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Dersleri DropDownList1'e yükle
                List<EntityDers> dersler = BLLDers.BllListele();
                DropDownList1.DataSource = dersler;
                DropDownList1.DataTextField = "DERSAD";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

                // Öğrencileri DropDownList2'ye yükle
                List<EntityOgrenci> ogrenciler = BLLDers.BllListeleOgrenci();
                Repeater2.DataSource = ogrenciler;
                Repeater2.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDersID = Convert.ToInt32(DropDownList1.SelectedValue);

            // Seçilen derse kayıtlı öğrencileri bul
            List<EntityBasvuruForm> kayitliOgrenciler = BLLDers.BllListeleKontenjan(selectedDersID);

                foreach (var basvuru in kayitliOgrenciler)
                {
                    // Öğrenci bilgilerini doldur
                    basvuru.Ogrenci = BLLDers.BllListeleOgrenci().Find(o => o.ID == basvuru.BASOGRID);

                    // Ders bilgilerini doldur
                    basvuru.Ders = BLLDers.BllListele().Find(d => d.ID == basvuru.BASDERSID);
                }

                // Kayıtlı öğrencileri DropDownList2'ye yükle
                Repeater2.DataSource = kayitliOgrenciler;
                Repeater2.DataBind();
        }
        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.DataItem is EntityOgrenci)
                {
                    EntityOgrenci item = (EntityOgrenci)e.Item.DataItem;

                    Literal LiteralAd = (Literal)e.Item.FindControl("LiteralAd");
                    Literal LiteralSoyad = (Literal)e.Item.FindControl("LiteralSoyad");

                    if (item != null)
                    {
                        LiteralAd.Text = item.AD;
                        LiteralSoyad.Text = item.SOYAD;
                    }
                }
                if (e.Item.DataItem is EntityBasvuruForm)
                {
                    EntityBasvuruForm item = (EntityBasvuruForm)e.Item.DataItem;

                    Literal LiteralAd = (Literal)e.Item.FindControl("LiteralAd");
                    Literal LiteralSoyad = (Literal)e.Item.FindControl("LiteralSoyad");

                    if (item != null)
                    {
                        LiteralAd.Text = item.Ogrenci.AD;
                        LiteralSoyad.Text = item.Ogrenci.SOYAD;
                    }
                }
            }
        }
    }
}