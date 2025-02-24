using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiyLayer
{
    public class EntityBasvuruForm
    {
        private int basvuruid;
        private int basdersid;
        private int basogrid;

        public int BASVURUID { get => basvuruid; set => basvuruid = value; }
        public int BASDERSID { get => basdersid; set => basdersid = value; }
        public int BASOGRID { get => basogrid; set => basogrid = value; }
        // Başvurunun öğrencisini temsil eden bir özellik ekleyin
        public EntityOgrenci Ogrenci { get; set; }

        // Başvurunun dersini temsil eden bir özellik ekleyin
        public EntityDers Ders { get; set; }
    }
}
