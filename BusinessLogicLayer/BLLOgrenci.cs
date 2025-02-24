using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntiyLayer;
using DataAccesLayer;


/*Proje başlayacak, önce EntityLayer a gidecek ordan EntityOgrenci deki değişkenleri hafızaya alacak.*/

namespace BusinessLogicLayer
{
    public class BLLOgrenci
    {
        /*Sonra buraya gelecek ve bu değişkenlere değer atanıp atanmadığını if ile kontrol edecek.Eğerki değer atanmışsa DALOgrenci 
        sınıfındaki OgrenciEkle metoduna gelecek ve @p değerlerini yazdıracak.*/
        public static int OgrenciEkleBLL(EntityOgrenci parametre)
        {
            if (parametre.AD != null && parametre.SOYAD != null & parametre.NUMARA != null & parametre.SIFRE != null & parametre.FOTOGRAF != null)
            {
                return DALOgrenci.OgrenciEkle(parametre);
            }
            return -1;
        }
        /*Sonra buraya gelecek ve OgrenciListesi ni okuyacak, DALOgrenci sınıfına gidecek ve OgrenciListesindeki verileri okuyacak eğer
         okuma işlemi başarılıysa OgrenciListesini geriye döndürecek.*/
        public static List<EntityOgrenci> BllListele()
        {
            return DALOgrenci.OgrenciListesi();
        }
        public static bool OgrenciSilBLL(int p)
        {
            if (p >= 0)
            {
                return DALOgrenci.OgrenciSil(p);
            }
            return false;
        }
        public static List<EntityOgrenci> BllDetay(int p)
        {
            return DALOgrenci.OgrenciDetay(p);
        }
        public static bool OgrenciGuncelleBLL(EntityOgrenci p)
        {
            if (p.AD != null && p.AD != "" && p.SOYAD != null && p.SOYAD != "" && p.NUMARA != null && p.NUMARA != "" && p.SIFRE != null && p.SIFRE != "" && p.FOTOGRAF != null && p.FOTOGRAF != "" && p.ID > 0)
            {
                return DALOgrenci.OgrenciGuncelle(p);
            }
            return false;
        }
    }
}
