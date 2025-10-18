using UnityEngine;

public abstract class IUIListOfAllUsersInfo: UIShowUserInfoInPanel
{
    public abstract void ShowFirstUser();
    public abstract void GetNextUser();
    public abstract void GetPreviousUser();
    public abstract void DeactivateNextButton();
    public abstract void ActivateNextButton();
    public abstract void DeactivatePreviousButton();
    public abstract void ActivatePreviousButton();
    public abstract GameObject GetGameOBject();
}