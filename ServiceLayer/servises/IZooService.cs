using DataLayer.Entitys;
using ServiceLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.servises
{
    public interface IZooService
    {
        List<UserDTO> UserDTOs { get; set; }

        UserKunder AddKunder(User user, Kunder kunder);
        int Commit();
        List<User> GetAllInfo(User user, int dyrID);
        Dyr getdyrbyid(int id);
        UserDyr KobDyr(User user, Dyr dyr);
        User LoadUser(string ID);
        User NewUser(string Navn, string NyId);
        bool TjekOmKanKoobe(User user, Dyr dyr);
        Task<decimal?> UpdatePenge(User user);
    }
}