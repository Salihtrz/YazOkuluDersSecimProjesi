using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntiyLayer; //Solution Explorer->References->Add References->Projects->Solution->EntityLayer yolunu takip ederek EntityLayer ı bu sınıftada kullanabiliriz.

namespace DataAccesLayer
{
    public class DALOgrenci
    {
        public static int OgrenciEkle(EntityOgrenci parametre)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrenci (ogrAd,ogrSoyad,ogrNumara,ogrFoto,ogrSifre) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if(komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            komut.Parameters.AddWithValue("@p1", parametre.AD);
            komut.Parameters.AddWithValue("@p2", parametre.SOYAD);
            komut.Parameters.AddWithValue("@p3", parametre.NUMARA);
            komut.Parameters.AddWithValue("@p4", parametre.FOTOGRAF);
            komut.Parameters.AddWithValue("@p5", parametre.SIFRE);
            return komut.ExecuteNonQuery();
        }
        public static List<EntityOgrenci> OgrenciListesi()
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Ogrenci", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.ID = Convert.ToInt32(oku["ogrID"].ToString());
                ent.AD = oku["ogrAd"].ToString();
                ent.SOYAD = oku["ogrSoyad"].ToString();
                ent.NUMARA = oku["ogrNumara"].ToString();
                ent.FOTOGRAF = oku["ogrFoto"].ToString();
                ent.SIFRE = oku["ogrSifre"].ToString();
                ent.BAKIYE = Convert.ToDouble(oku["ogrBakiye"].ToString());
                degerler.Add(ent);
            }
            oku.Close();
            return degerler;
        }
        public static bool OgrenciSil(int parametre)
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Ogrenci where ogrID=@p1", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            komut.Parameters.AddWithValue("@p1", parametre);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntityOgrenci> OgrenciDetay(int id)
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("Select * from Tbl_Ogrenci where ogrID = @p1", Baglanti.bgl);
            komut.Parameters.AddWithValue("@p1", id);
            if (komut.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.AD = oku["ogrAd"].ToString();
                ent.SOYAD = oku["ogrSoyad"].ToString();
                ent.NUMARA = oku["ogrNumara"].ToString();
                ent.FOTOGRAF = oku["ogrFoto"].ToString();
                ent.SIFRE = oku["ogrSifre"].ToString();
                ent.BAKIYE = Convert.ToDouble(oku["ogrBakiye"].ToString());
                degerler.Add(ent);
            }
            oku.Close();
            return degerler;
        }
        public static bool OgrenciGuncelle(EntityOgrenci deger)
        {
            SqlCommand komut5 = new SqlCommand("Update Tbl_Ogrenci set ogrAd=@p1,ogrSoyad=@p2,ogrNumara=@p3,ogrFoto=@p4,ogrSifre=@p5 where ogrID=@p6", Baglanti.bgl);
            if (komut5.Connection.State != ConnectionState.Open) //Bağlantı açık mı kapalı mı onu kontrol eder.
            {
                komut5.Connection.Open(); //Eğer bağlantı kapalıysa bağlantıyı aç
            }
            komut5.Parameters.AddWithValue("@p1", deger.AD);
            komut5.Parameters.AddWithValue("@p2", deger.SOYAD);
            komut5.Parameters.AddWithValue("@p3", deger.NUMARA);
            komut5.Parameters.AddWithValue("@p4", deger.FOTOGRAF);
            komut5.Parameters.AddWithValue("@p5", deger.SIFRE);
            komut5.Parameters.AddWithValue("@p6", deger.ID);
            return komut5.ExecuteNonQuery() > 0;
        }
    }
}
