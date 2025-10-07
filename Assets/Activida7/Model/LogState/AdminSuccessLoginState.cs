public class AdminSuccessLoginState : ILoginState
{
    public void LogUser(IPresenterLogin loginPresenter)
    {
        loginPresenter.TellToUILoginToLogAnAdmin();
    }
}