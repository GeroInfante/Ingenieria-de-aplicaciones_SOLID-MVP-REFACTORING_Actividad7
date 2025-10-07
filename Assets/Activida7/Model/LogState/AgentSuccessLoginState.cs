public class AgentSuccessLoginState : ILoginState
{
    public void LogUser(IPresenterLogin loginPresenter)
    {
        loginPresenter.TellToUILoginToLogAnAgent();
    }
}