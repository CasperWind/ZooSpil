namespace ServiceLayer.DTO
{
    public interface IUserDTO
    {
        int? DyrID { get; set; }
        string DyrNavn { get; set; }
        int? KundeID { get; set; }
        string KundeNavn { get; set; }
        string Navn { get; set; }
        decimal Penge { get; set; }
        int UserId { get; set; }
    }
}