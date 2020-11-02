using DataLayer.Entitys;

namespace ServiceLayer.servises
{
    public interface IZooService
    {
        UserKunder AddKunder(User user, Kunder kunder);
        int Commit();
        UserDyr KobDyr(User user, Dyr dyr);
        User LoadUser(string ID);
        User NewUser(string Navn);
        decimal UpdatePenge(User user, Kunder kunder);
    }
}