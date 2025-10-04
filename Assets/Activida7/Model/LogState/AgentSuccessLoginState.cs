public class AgentSuccessLoginState : LoginState
{
    public override void LogUser()
    {
        LoginPresenter.TellToUILoginToLogAnAgent();
    }
}