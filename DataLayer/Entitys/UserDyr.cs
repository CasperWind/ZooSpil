using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entitys
{
    public class UserDyr
    {
        public string UserId { get; set; }
        public int DyrId { get; set; }
        public int Antal { get; set; }

        public User User { get; set; }
        public Dyr Dyr { get; set; }

    }
}
