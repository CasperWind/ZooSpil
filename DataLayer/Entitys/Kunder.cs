using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entitys
{
    public class Kunder
    {
        
        public int KunderId { get; set; }
        public string Navn { get; set; }

        public ICollection<UserKunder> UserKunders { get; set; }
    }
}
