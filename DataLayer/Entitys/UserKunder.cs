using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace DataLayer.Entitys
{
    public class UserKunder
    {
        public string UserID { get; set; }
        public int KundeId { get; set; }
        public int Antal { get; set; }

        public User User { get; set; }
        public Kunder Kunder { get; set; }
    }
}
