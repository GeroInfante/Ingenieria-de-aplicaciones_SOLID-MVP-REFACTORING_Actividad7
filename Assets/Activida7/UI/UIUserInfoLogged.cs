
public class UIUserInfoLogged : IUIUserInfoLogged
{
    public IPresenterUserInfoLogged userInfoPresenter;

    public override void ShowuserInfoPanel()
    {
        userInformationPanel.SetActive(true);
        PreviousPanel.SetActive(false);
    }
    public override void ShowUserInfo(string username)
    {
        userInfoPresenter.showUser(username);
    }

    // Start is called before the first frame update
    void Start()
    {
        userInfoPresenter = new PresenterUserInfoLogged(this);
        userInformationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
