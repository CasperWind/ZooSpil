using DataLayer;
using DataLayer.Entitys;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.servises
{
    public class ZooService : IZooService
    {
        public decimal? Prisen { get; set; }
        public List<UserDTO> UserDTOs { get; set; }

        private readonly ZooContext _ctx;
        public ZooService(ZooContext ctx)
        {
            _ctx = ctx;
        }

        public User NewUser(string Navn, string NyId)
        {

            User newUser = new User()
            {
                UserId = NyId,
                Penge = 10000,
                Navn = Navn,
            };
            _ctx.Users.Add(newUser);
            List<UserDyr> userDyr = new List<UserDyr>();
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 1, Antal = 0 });
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 2, Antal = 0 });
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 3, Antal = 0 });
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 4, Antal = 0 });
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 5, Antal = 0 });
            userDyr.Add(new UserDyr { UserId = NyId, DyrId = 6, Antal = 0 });

            _ctx.UserDyrs.AddRange(userDyr);
            List<UserKunder> userKunders = new List<UserKunder>();
            userKunders.Add(new UserKunder { UserID = NyId, KundeId = 1, Antal = 0 });
            userKunders.Add(new UserKunder { UserID = NyId, KundeId = 2, Antal = 0 });
            userKunders.Add(new UserKunder { UserID = NyId, KundeId = 3, Antal = 0 });
            _ctx.UserKunders.AddRange(userKunders);

            _ctx.SaveChanges();
            return newUser;
        }
        public User LoadUser(string ID)
        {
            User LoaedeUser = _ctx.Users.Find(ID);
            return LoaedeUser;
        }
        public int Commit()
        {
            _ctx.SaveChanges();
            return 0;
        }

        public UserDyr KobDyr(User user, Dyr dyr)
        {
            UserDyr userOgDyr = _ctx.UserDyrs.Where(u => u.UserId == user.UserId && u.DyrId == dyr.DyrId).FirstOrDefault();

            userOgDyr.Antal += 1;
            _ctx.SaveChanges();
            return userOgDyr;
        }

        public UserKunder AddKunder(User user, int kunderId)
        {
            UserKunder userOgKunder = _ctx.UserKunders.Where(u => u.UserID == user.UserId && u.KundeId == kunderId).FirstOrDefault();
            Random randomKunder = new Random();

            switch (userOgKunder.KundeId)
            {
                case 1:
                    userOgKunder.Antal += randomKunder.Next(1, 3);
                    break;
                case 2:
                    userOgKunder.Antal += randomKunder.Next(4, 7);
                    break;
                case 3:
                    userOgKunder.Antal += randomKunder.Next(2, 4);
                    break;
                default:
                    break;
            }

            _ctx.SaveChanges();
            return userOgKunder;
        }
        public async Task<decimal?> UpdatePenge(User user)
        {
            var antalKunder = _ctx.UserKunders.Where(x => x.User.UserId == user.UserId);
            decimal? startPenge = user.Penge / 9;
            decimal? alleKunder = antalKunder.Sum(x => x.Antal);
            decimal? filter = (decimal?)0.20;
            Random randomKunder = new Random();
            if (alleKunder != 0)
            {
                alleKunder *= filter;
                decimal? belob = 250 * alleKunder;
                user.Penge += (decimal)belob;
                return belob;
            }
            return user.Penge;


        }
        public bool TjekOmKanKoobe(User user, Dyr dyr)
        {

            var beregnprisen = _ctx.UserDyrs.Where(x => x.UserId == user.UserId && x.DyrId == dyr.DyrId).FirstOrDefault();
            if (beregnprisen.Antal == 0 && user.Penge >= 10000)
            {
                user.Penge -= dyr.Pris;

                return true;
            }
            if (beregnprisen != null && beregnprisen.Antal != 0)
            {
                Prisen = dyr.Pris * beregnprisen.Antal;
            }
            if (user.Penge >= Prisen)
            {
                user.Penge -= (decimal)Prisen;
                return true;
            }
            return false;
        }
        public List<UserDyr> GetAllDyrFromUser(User user)
        {
            return _ctx.UserDyrs
                .Include(x => x.Dyr)
                .Where(x => x.UserId == user.UserId)
                .ToList();


        }
        public Dyr getdyrbyid(int id)
        {
            return _ctx.Dyrs.Where(x => x.DyrId == id).FirstOrDefault();
        }
        public void ADMINMODE(User user)
        {
            user.Penge += 1000000;
            _ctx.SaveChanges();
        }
        public List<UserKunder> GetAllKunderFromUser(User user)
        {
            var kundetest = _ctx.UserKunders
                .Include(x => x.Kunder)
                .Where(x => x.UserID == user.UserId)
                .ToList();

            return kundetest;
        }
    }
}
