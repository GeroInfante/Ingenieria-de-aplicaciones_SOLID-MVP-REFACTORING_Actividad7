using UnityEngine;
using UnityEngine.UI;

public class UIListOfAllUsersInfo : IUIListOfAllUsersInfo
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
    
    public override void ShowFirstUser()
    {
        presenterListOfAllUsers.GetFirstAgent();
    }

    public override void GetNextUser()
    {
        presenterListOfAllUsers.GetNextUser();
    }

    public override void GetPreviousUser()
    {
        presenterListOfAllUsers.GetPreviousUser();
    }

    // Implemented to satisfy IUIListOfAllUsersInfo interface
    public override GameObject GetGameOBject()
    {
        return this.gameObject;
    }

    public override void DeactivateNextButton()
    {
        next.gameObject.SetActive(false);
    }

    public override void ActivateNextButton()
    {
        next.gameObject.SetActive(true);
    }

    public override void DeactivatePreviousButton()
    {
        previous.gameObject.SetActive(false);
    }

    public override void ActivatePreviousButton()
    {
        previous.gameObject.SetActive(true);
    }
}