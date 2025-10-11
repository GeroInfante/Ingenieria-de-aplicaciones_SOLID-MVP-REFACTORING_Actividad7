using UnityEngine;
using UnityEngine.UI;

public class UIListOfAllUsersInfo : UIShowUserInfoInPanel, IUIListOfAllUsersInfo
{
    public Button next, previous;
    private IPresenterListOfAllUsers presenterListOfAllUsers;
    void Start()
    {
        userInformationPanel.SetActive(false);
        presenterListOfAllUsers = new PresenterListUsersInfo(this);
    }
    void Update()
    {

    }
    
    public void ShowFirstUser()
    {
        presenterListOfAllUsers.GetFirstAgent();
    }

    public void GetNextUser()
    {
        presenterListOfAllUsers.GetNextUser();
    }

    public void GetPreviousUser()
    {
        presenterListOfAllUsers.GetPreviousUser();
    }

    public void DeactivateNextButton()
    {
        next.gameObject.SetActive(false);
    }

    public void ActivateNextButton()
    {
        next.gameObject.SetActive(true);
    }

    public void DeactivatePreviousButton()
    {
        previous.gameObject.SetActive(false);
    }

    public void ActivatePreviousButton()
    {
        previous.gameObject.SetActive(true);
    }
}