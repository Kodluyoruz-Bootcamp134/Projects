namespace Base.Projections.UserService;

public interface IMailService
{
    Task Send(string toMailAdress, string message, string subject);
}