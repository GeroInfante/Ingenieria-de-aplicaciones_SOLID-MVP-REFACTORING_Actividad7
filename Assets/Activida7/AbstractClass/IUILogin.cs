using UnityEngine;

public abstract class IUILogin: MonoBehaviour
{
    public abstract void LoginUser();
    public abstract void showUser();
    public abstract void ShowAdmin();
    public abstract void showUserNotFound();
    public abstract void showIncorrectPassword();
}