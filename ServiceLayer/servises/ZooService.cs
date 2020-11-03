using DataLayer;
using DataLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.servises
{
    public class ZooService : IZooService
    {
        //public ZooService()
        //{

        //}

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

            if (userOgDyr == null)
            {
                userOgDyr = new UserDyr()
                {
                    UserId = user.UserId,
                    DyrId = dyr.DyrId,
                    Antal = 1
                };
                _ctx.Add(userOgDyr);
                _ctx.SaveChanges();
                return userOgDyr;
            }
            userOgDyr.Antal += 1;
            _ctx.SaveChanges();
            return userOgDyr;
        }

        public UserKunder AddKunder(User user, Kunder kunder)
        {
            UserKunder userOgKunder = _ctx.UserKunders.Where(u => u.UserID == user.UserId && u.KundeId == kunder.KundeId).FirstOrDefault();

            if (userOgKunder == null)
            {
                userOgKunder = new UserKunder()
                {
                    UserID = user.UserId,
                    KundeId = kunder.KundeId,
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
        public decimal? UpdatePenge(User user, Kunder kunder)
        {
            var antalKunder = _ctx.UserKunders.Where(x => x.User.UserId == user.UserId);
            decimal? startPenge = 100;
            int? alleKunder = 0;

            foreach (var item in antalKunder)
            {
                alleKunder += item.Antal;
            }

            decimal? belob = startPenge * alleKunder;
            return belob;

        }
        public bool TjekOmKanKoobe(User user, Dyr dyr)
        {
            if (user.Penge >= dyr.Pris)
            {
                return true;
            }
            return false;
        }
    }
}
