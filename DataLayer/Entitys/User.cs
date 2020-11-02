using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entitys
{
    public class User
    {
        public string UserId { get; set; }
        public decimal Penge { get; set; }
        public string Navn { get; set; }




        public ICollection<UserDyr> userDyrs { get; set; }
        public ICollection<UserKunder>  UserKunders { get; set; }

    }
}
