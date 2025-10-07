public class IncorrectPasswordLoginState : ILoginState
{
    public void LogUser(IPresenterLogin loginPresenter)
    {
        loginPresenter.TellToUILoginToShowIncorrectPassword();
    }
}