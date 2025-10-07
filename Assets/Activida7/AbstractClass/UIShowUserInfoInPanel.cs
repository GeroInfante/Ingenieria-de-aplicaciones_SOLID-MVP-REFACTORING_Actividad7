using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class UIShowUserInfoInPanel : MonoBehaviour, IUIShowUserInfoInPanel
{
    public TextMeshProUGUI agentName, agentLastName, agentAge, agentPhone, agentAddress, agentEmail;
    public Button logout;
    public Image agentImage;
    public GameObject PreviousPanel;
    public GameObject userInformationPanel;
    public void LogoutUser()
    {
        PreviousPanel.SetActive(true);
        userInformationPanel.SetActive(false);
    }
    public void showName(string name)
    {
        agentName.text = name;     
    }
    public void showLastName(string lastName)
    {
        agentLastName.text = lastName;
    }
    public void showAge(string age)
    {
        agentAge.text = age;
    }
    public void showPhone(string phone)
    {
        agentPhone.text = phone;
    }
    public void showAddress(string address)
    {
        agentAddress.text = address;
    }
    public void showEmail(string email)
    {
        agentEmail.text = email;
    }
    public void showImage(Sprite image)
    {
        agentImage.sprite = image;
    }
}