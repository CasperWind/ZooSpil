using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entitys
{
    public class Kunder
    {
        [Key]
        public int KundeId { get; set; }
        public string Navn { get; set; }

        public ICollection<UserKunder> UserKunders { get; set; }
    }
}
