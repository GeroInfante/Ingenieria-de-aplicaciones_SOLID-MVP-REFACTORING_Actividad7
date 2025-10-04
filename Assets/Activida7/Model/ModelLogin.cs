
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

        if (usernameNotFound(username))
        {
            loginState = new UsernameNotFoundLoginState();
        }
        else
        {
            if (passwordIsInvalid(username, password))
            {
                loginState = new IncorrectPasswordLoginState();
            }
            else
            {
                loginState = new AgentSuccessLoginState();
            }
        }
        return loginState;
    }

    private bool usernameNotFound(string username)
    {
        return !localFileService.CheckIfUserExist(username);
    }

    private bool passwordIsInvalid(string username, string password)
    {
        return !localFileService.CheckIfPasswordIsCorrect(username, password);
    }
}
