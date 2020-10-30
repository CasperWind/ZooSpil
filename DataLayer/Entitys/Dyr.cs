using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entitys
{
    public class Dyr
    {
        public int DyrId { get; set; }
        public string Navn { get; set; }
        public int Antal { get; set; }

        public User User { get; set; }
    }
}
