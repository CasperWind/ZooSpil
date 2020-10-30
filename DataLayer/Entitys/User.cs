using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entitys
{
    public class User
    {
        public int UserId { get; set; }
        public decimal Penge { get; set; }
        public string Navn { get; set; }


        public int? DyrID { get; set; }
        public int? KundeID { get; set; }

        public ICollection<Dyr> Dyrs { get; set; }
        public ICollection<Kunder> Kunders { get; set; }
    }
}
