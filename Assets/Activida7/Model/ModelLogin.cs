
using System.Diagnostics;

public class ModelLogin : IModelLogin
{
    public ILocalFileService localFileService;
    public ModelLogin()
    {
        localFileService = new LocalFilesService();
    }
    public ILoginState authenticateLogin(string username, string password)
    {
        ILoginState loginState;

        if (UsernameNotFound(username))
        {
            loginState = new UsernameNotFoundLoginState();
        }
        else
        {
            if (PasswordIsInvalid(username, password))
            {
                loginState = new IncorrectPasswordLoginState();
            }
            else
            {
                if (IsAdmin(username))
                {
                    UnityEngine.Debug.Log("No ");
                    loginState = new AdminSuccessLoginState();
                }
                else
                    loginState = new AgentSuccessLoginState();

            }
        }
        return loginState;
    }

    private bool UsernameNotFound(string username)
    {
        return !localFileService.CheckIfUserExist(username);
    }

    private bool PasswordIsInvalid(string username, string password)
    {
        return !localFileService.CheckIfPasswordIsCorrect(username, password);
    }

    private bool IsAdmin(string username)
    {
       return localFileService.CheckIfIsAdmin(username);
    }
}
