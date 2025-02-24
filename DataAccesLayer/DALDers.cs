using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntiyLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccesLayer
{
    public class DALDers
    {
        public static List<EntityDers> DersListesi()
        {
            List<EntityDers> degerler = new List<EntityDers>();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Dersler", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityDers ent = new EntityDers();
                ent.ID = Convert.ToInt32(oku["dersID"].ToString());
                ent.DERSAD = oku["dersAd"].ToString();
                ent.MIN = Convert.ToInt32(oku["dersMinKontenjan"].ToString());
                ent.MAX = int.Parse(oku["dersMaxKontenjan"].ToString());
                degerler.Add(ent);
            }
            oku.Close();
            return degerler;
        }
		public static List<EntityOgrenci> OgrenciListesi()
		{
			List<EntityOgrenci> kisiler = new List<EntityOgrenci>();
			SqlCommand komut = new SqlCommand("Select * from Tbl_Ogrenci", Baglanti.bgl);
			if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
			{
				komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
			}
			SqlDataReader oku = komut.ExecuteReader();
			while (oku.Read())
			{
				EntityOgrenci ent2 = new EntityOgrenci();
				ent2.ID = Convert.ToInt32(oku["ogrID"].ToString());
				ent2.AD = oku["ogrAd"].ToString();
				ent2.SOYAD = oku["ogrSoyad"].ToString();
				ent2.FOTOGRAF = oku["ogrFoto"].ToString();
				ent2.NUMARA = oku["ogrNumara"].ToString();
				ent2.BAKIYE = Convert.ToDouble(oku["ogrBakiye"].ToString());
				ent2.SIFRE = oku["ogrSifre"].ToString();
				kisiler.Add(ent2);
			}
			oku.Close();
			return kisiler;
		}
		public static int TalepEkle(EntityBasvuruForm p)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_BasvuruForm (dersID, ogrenciID) values (@p1,@p2)", Baglanti.bgl);
            komut.Parameters.AddWithValue("@p1", p.BASOGRID);
            komut.Parameters.AddWithValue("@p2", p.BASDERSID);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            return komut.ExecuteNonQuery();
        }
        public static List<EntityBasvuruForm> KontenjanListesi(int id)
        {
            List<EntityBasvuruForm> degerler = new List<EntityBasvuruForm>();
            SqlCommand komut = new SqlCommand("Select * from Tbl_BasvuruForm where dersID=@p1", Baglanti.bgl);
            komut.Parameters.AddWithValue("p1", id);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityBasvuruForm ent = new EntityBasvuruForm();
                ent.BASOGRID = Convert.ToInt32(oku["ogrenciID"].ToString());
                ent.BASDERSID = Convert.ToInt32(oku["dersID"].ToString());
                degerler.Add(ent);
            }
            oku.Close();
            return degerler;
        }
    }
}
