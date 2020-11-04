using DataLayer.Entitys;
using System.Threading.Tasks;

namespace ServiceLayer.servises
{
    public interface IZooService
    {
        UserKunder AddKunder(User user, Kunder kunder);
        int Commit();
        UserDyr KobDyr(User user, Dyr dyr);
        User LoadUser(string ID);
        User NewUser(string Navn, string NyId);
        bool TjekOmKanKoobe(User user, Dyr dyr);
        Task<decimal?> UpdatePenge(User user);
    }
}