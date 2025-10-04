public class AdminSuccessLoginState : LoginState
{
    public override void LogUser()
    {
        LoginPresenter.TellToUILoginToLogAnAdmin();
    }
}