public abstract class LoginState : ILoginState
{
    public IPresenterLogin LoginPresenter;
    public abstract void LogUser();
    public void SetLoginPresenter(IPresenterLogin loginPresenterToSet)
    {
        LoginPresenter = loginPresenterToSet;
    }
} 