public class UsernameNotFoundLoginState : ILoginState
{
    public void LogUser(IPresenterLogin loginPresenter)
    {
        loginPresenter.TellToUILoginToShowUserNotFound();
    }
}