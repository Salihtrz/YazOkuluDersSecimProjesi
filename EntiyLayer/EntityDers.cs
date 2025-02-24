using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntiyLayer
{
    public class EntityDers
    {
        private string dersad;
        private int Min;
        private int Max;
        private int id;
        public string DERSAD { get => dersad; set => dersad = value; }
        public int MIN { get => Min; set => Min = value; }
        public int MAX { get => Max; set => Max = value; }
        public int ID { get => id; set => id = value; }
        public ICollection<EntityBasvuruForm> Basvurular { get; set; }
    }
}
