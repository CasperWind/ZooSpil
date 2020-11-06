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

        /// <summary>
        /// HEr bliver der lave en ny user. 
        /// og lavet alle dyr og kunder som skal passe til den user. ID'et kommer fra NyZooNavn siden. Og det samme med navn.
        /// </summary>
        /// <param name="Navn">Navnet op Zooen. String.</param>
        /// <param name="NyId">Et random id som er lavet med Guid</param>
        /// <returns></returns>
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
            userKunders.Add(new UserKunder { UserID = NyId, KunderId = 1, Antal = 0 });
            userKunders.Add(new UserKunder { UserID = NyId, KunderId = 2, Antal = 0 });
            userKunders.Add(new UserKunder { UserID = NyId, KunderId = 3, Antal = 0 });
            _ctx.UserKunders.AddRange(userKunders);

            _ctx.SaveChanges();
            return newUser;
        }

        /// <summary>
        /// Her loader vi Useren fra den cookie der er lavet
        /// </summary>
        /// <param name="ID">Id modtager vi fra cookien.</param>
        /// <returns></returns>
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

        /// <summary>
        /// her køber vi et dyr. 
        /// </summary>
        /// <param name="user">Er den User som er igang med spillet.</param>
        /// <param name="dyr">Det dyr som han køber.</param>
        /// <returns></returns>
        public UserDyr KobDyr(User user, Dyr dyr)
        {
            UserDyr userOgDyr = _ctx.UserDyrs.Where(u => u.UserId == user.UserId && u.DyrId == dyr.DyrId).FirstOrDefault();

            userOgDyr.Antal += 1;
            _ctx.SaveChanges();
            return userOgDyr;
        }

        /// <summary>
        /// her bliver det addede kunner alt efter hvilket dyr der bliver købt. 
        /// </summary>
        /// <param name="user">Selve Useren</param>
        /// <param name="kunderId">Selve KundeID'et</param>
        /// <returns></returns>
        public UserKunder AddKunder(User user, int kunderId)
        {
            UserKunder userOgKunder = _ctx.UserKunders.Where(u => u.UserID == user.UserId && u.KunderId == kunderId).FirstOrDefault();
            Random randomKunder = new Random();

            switch (userOgKunder.KunderId)
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

        /// <summary>
        /// Her blvier userens penge opdateret hvert sekunt.
        /// </summary>
        /// <param name="user">Selve Useren</param>
        /// <returns></returns>
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
                decimal? belob = 500 * alleKunder;
                user.Penge += (decimal)belob;
                return belob;
            }
            return user.Penge;


        }

        /// <summary>
        /// Her tjekker vi om Useren kan købe det dyr han gerne vil købe.
        /// Hvis han har penge nok så får han true. hvis ikke så false
        /// Hvis du har 0 af dyret så tjekker den om du har råd til dyret. også tager den penge. derefter regner den prisen ud som nede under.
        /// og har regner vi prisen ud også. start prisen på dyret * antal at dyret = prisen.
        /// </summary>
        /// <param name="user">Useren som spiller</param>
        /// <param name="dyr">Det dyr han vil købe</param>
        /// <returns></returns>
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

        /// <summary>
        /// Her får vi alle dyr som en user har. 
        /// </summary>
        /// <param name="user">Useren som spiller</param>
        /// <returns></returns>
        public List<UserDyr> GetAllDyrFromUser(User user)
        {
            return _ctx.UserDyrs
                .Include(x => x.Dyr)
                .Where(x => x.UserId == user.UserId)
                .ToList();


        }

        /// <summary>
        /// Her får vi det dyr objekt som vi vil pille ved.
        /// </summary>
        /// <param name="id">Idede på det dyr.</param>
        /// <returns></returns>
        public Dyr getdyrbyid(int id)
        {
            return _ctx.Dyrs.Where(x => x.DyrId == id).FirstOrDefault();
        }

        /// <summary>
        /// MotherLode.
        /// </summary>
        /// <param name="user">Useren selv</param>
        public void ADMINMODE(User user)
        {
            user.Penge += 1000000;
            _ctx.SaveChanges();
        }

        /// <summary>
        /// her får vi alle kunder som høre til useren
        /// </summary>
        /// <param name="user">Useren som spiller.</param>
        /// <returns></returns>
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
