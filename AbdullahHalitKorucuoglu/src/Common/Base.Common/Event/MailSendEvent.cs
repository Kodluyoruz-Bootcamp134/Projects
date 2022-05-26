namespace Base.Common.Event;

public class MailSendEvent
{
    public string MailAdress { get; set; }
    public string Message { get; set; }
    public string Subject { get; set; }
}