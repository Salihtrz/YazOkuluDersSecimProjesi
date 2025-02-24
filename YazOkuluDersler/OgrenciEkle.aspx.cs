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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Proje ilk olarak Entity katmanından başlıyor. DataAccessLayer üzerinde değişkenlere değer ataması gerçekleştiriyoruz.
        // Daha sonra BusinessLogicLayer katmanına gidiyor ve eğerki oradaki şart sağlanıyorsa bizi sunum katmanına götürüyo ve istediğimiz değerleri döndürüyor.
        protected void Button1_Click(object sender, EventArgs e)
        {
            EntityOgrenci ent = new EntityOgrenci();
            ent.AD = TxtAd.Text;
            ent.SOYAD = TxtSoyad.Text;
            ent.NUMARA = TxtNumara.Text;
            ent.SIFRE = TxtSifre.Text;
            ent.FOTOGRAF = TxtFoto.Text;
            BLLOgrenci.OgrenciEkleBLL(ent);
			Response.Redirect("OgrenciListesi.aspx");
		}
    }
}