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

            if (userOgKunder == null)
            {
                userOgKunder = new UserKunder()
                {
                    UserID = user.UserId,
                    KundeId = kunderId,
                    Antal = 1
                };
                _ctx.Add(userOgKunder);
                _ctx.SaveChanges();
                return userOgKunder;
            }
            userOgKunder.Antal += 1;
            _ctx.SaveChanges();
            return userOgKunder;
        }
        public async Task<decimal?> UpdatePenge(User user)
        {
            var antalKunder = _ctx.UserKunders.Where(x => x.User.UserId == user.UserId);
            decimal? startPenge = user.Penge / 9;
            decimal? alleKunder = (decimal?)2;
            decimal? filter = (decimal?)0.20;
            Random randomKunder = new Random();
            foreach (var item in antalKunder)
            {
                if (item.Antal > 0)
                {
                    alleKunder += item.Antal;
                }
            }
            alleKunder *= filter;
            decimal? belob = startPenge * alleKunder;
            user.Penge += (decimal)belob;
            return belob;

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
            user.Penge += 100000000;
            _ctx.SaveChanges();
        }
        public List<UserKunder> GetAllKunderFromUser(User user)
        {
            return _ctx.UserKunders
                .Include(x => x.Kunder)
                .Where(x => x.UserID == user.UserId)
                .ToList();
        }
    }
}
