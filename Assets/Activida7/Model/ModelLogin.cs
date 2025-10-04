
using System.Diagnostics;

public class ModelLogin : IModelLogin
{
    public ILocalFileService localFileService;
    public ITypeOfUserLogin typeOfUserLoging;

    public ModelLogin()
    {
        localFileService = new LocalFilesService();
        typeOfUserLoging = new TypeOfUserLogin();
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
                    UnityEngine.Debug.Log("Es Admin");
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
