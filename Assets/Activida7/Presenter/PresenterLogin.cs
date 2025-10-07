
using System;
using System.Threading.Tasks;

public class PresenterLogin : IPresenterLogin
{
    public IModelLogin loginModel;
    public UILogin loginUI;

    public PresenterLogin(UILogin loginUI)
    {
        this.loginUI = loginUI;
        loginModel = new ModelLogin();
    }

    public void Login(string usernameToVerify, string passwordToVerify)
    {
        ILoginState loginState = loginModel.authenticateLogin(usernameToVerify, passwordToVerify); // Me retorna un LogState
        loginState.LogUser(this);
    }
    public void TellToUILoginToLogAnAgent()
    {
        loginUI.showUser();
    }

    public void TellToUILoginToLogAnAdmin()
    {
        loginUI.ShowAdmin();
    }

    public void TellToUILoginToShowUserNotFound()
    {
        loginUI.showUserNotFound();
    }
    public void TellToUILoginToShowIncorrectPassword()
    {
        loginUI.showIncorrectPassword();
    }

}
