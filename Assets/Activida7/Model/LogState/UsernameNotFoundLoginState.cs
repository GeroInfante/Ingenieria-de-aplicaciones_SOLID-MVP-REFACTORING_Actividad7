public class UsernameNotFoundLoginState : LoginState
{
    public override void LogUser()
    {
        LoginPresenter.TellToUILoginToShowUserNotFound();
    }
}