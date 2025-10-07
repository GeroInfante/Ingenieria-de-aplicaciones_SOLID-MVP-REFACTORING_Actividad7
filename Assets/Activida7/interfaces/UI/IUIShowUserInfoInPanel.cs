using UnityEngine;

public interface IUIShowUserInfoInPanel
{
    void LogoutUser();
    void showName(string name);
    void showLastName(string lastName);
    void showAge(string age);
    void showPhone(string phone);
    void showAddress(string address);
    void showEmail(string email);
    void showImage(Sprite image);
}