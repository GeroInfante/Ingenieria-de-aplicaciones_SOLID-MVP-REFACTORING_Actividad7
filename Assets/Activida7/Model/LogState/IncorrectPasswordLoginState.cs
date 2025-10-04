public class IncorrectPasswordLoginState : LoginState
{
    public override void LogUser()
    {
        LoginPresenter.TellToUILoginToShowIncorrectPassword();
    }
}