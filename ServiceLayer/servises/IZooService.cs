using DataLayer.Entitys;
using ServiceLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.servises
{
    public interface IZooService
    {
        decimal? Prisen { get; set; }
        List<UserDTO> UserDTOs { get; set; }

        UserKunder AddKunder(User user, int kunderId);
        void ADMINMODE(User user);
        int Commit();
        List<UserDyr> GetAllDyrFromUser(User user);
        List<UserKunder> GetAllKunderFromUser(User user);
        Dyr getdyrbyid(int id);
        UserDyr KobDyr(User user, Dyr dyr);
        User LoadUser(string ID);
        User NewUser(string Navn, string NyId);
        bool TjekOmKanKoobe(User user, Dyr dyr);
        Task<decimal?> UpdatePenge(User user);
    }
}