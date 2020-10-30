namespace ServiceLayer.DTO
{
    public interface IUserDTO
    {
        int? DyrID { get; set; }
        int? KundeID { get; set; }
        string Navn { get; set; }
        decimal Penge { get; set; }
        int UserId { get; set; }
    }
}