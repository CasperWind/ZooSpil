using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class UserDTO : IUserDTO
    {
        public int UserId { get; set; }
        public decimal Penge { get; set; }
        public string Navn { get; set; }
        public int? DyrID { get; set; }
        public int? KundeID { get; set; }
    }
}
