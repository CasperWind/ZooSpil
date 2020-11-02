using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entitys
{
    public class Dyr
    {
        public int DyrId { get; set; }
        public string Navn { get; set; }
        public decimal Pris { get; set; }


        public ICollection<UserDyr> UserDyrs { get; set; }
    }
}
