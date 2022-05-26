namespace Base.Api.Application.Models.Const;

public static class CustomResponseMessages
{
    #region UserService

    public const string UserNotFound = "User not found. Review your username and password";
    public const string EmailNotConfirmed = "Your email address has not been verified yet";
    public const string InvalidUrl = "This link is invalid";
    public const string EmailConfirmed = "address has been successfully verified";
    public const string EmailSended = "Necessary information has been sent to";
    public const string PasswordChanged = "The password has been successfully changed";
    public const string UserInfoChanged = "Your user information has been successfully changed";

    #endregion UserService

    #region NoteService

    public const string ArticleNotFound = "No such note was found.";

    #endregion NoteService
}