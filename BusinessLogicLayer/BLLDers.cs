using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntiyLayer;
using DataAccesLayer;

namespace BusinessLogicLayer
{
    public class BLLDers
    {
        public static List<EntityDers> BllListele()
        {
            return DALDers.DersListesi();
        }
		public static List<EntityOgrenci> BllListeleOgrenci()
		{
			return DALDers.OgrenciListesi();
		}
		public static int TalepEkleBLL(EntityBasvuruForm p)
        {
            if(p.BASOGRID != null && p.BASDERSID != null)
            {
                return DALDers.TalepEkle(p);
            }
            return -1;
        }
        public static List<EntityBasvuruForm> BllListeleKontenjan(int p)
        {
            return DALDers.KontenjanListesi(p);
        }
    }
}
