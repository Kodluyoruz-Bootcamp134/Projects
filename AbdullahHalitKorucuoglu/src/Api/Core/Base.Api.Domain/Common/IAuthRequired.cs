namespace Base.Api.Domain.Common;

public interface IAuthRequired
{
    public int ApplicationUserId { get; set; }
}