using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntiyLayer;
using BusinessLogicLayer;
using DataAccesLayer;

namespace YazOkuluDersler
{
    public partial class Dersler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                List<EntityDers> entDers = BLLDers.BllListele();
                DropDownList1.DataSource = BLLDers.BllListele();
                DropDownList1.DataTextField = "DERSAD";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();

				List<EntityOgrenci> entOgrenci = BLLDers.BllListeleOgrenci();
				DropDownList2.DataSource = BLLDers.BllListeleOgrenci();
				DropDownList2.DataTextField = "AD";
				DropDownList2.DataValueField = "ID";
				DropDownList2.DataBind();
			}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EntityBasvuruForm ent = new EntityBasvuruForm();
            ent.BASOGRID = int.Parse(DropDownList1.SelectedValue.ToString());
            ent.BASDERSID = int.Parse(DropDownList2.SelectedValue.ToString());
            BLLDers.TalepEkleBLL(ent);
        }
    }
}