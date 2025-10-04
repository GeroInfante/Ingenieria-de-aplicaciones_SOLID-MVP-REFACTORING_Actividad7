using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UIUserInfo : MonoBehaviour, IUIUserInfo
{
    public TextMeshProUGUI agentName, agentLastName, agentAge, agentPhone, agentAddress, agentEmail;
    public Button logout;
    public Image agentImage;
    public IPresenterUserInfo userInfoPresenter;
    public UILogin PanelUILogin;
    public GameObject PanelInfoUser;

    public void ShowuserInfoPanel()
    {
        PanelInfoUser.SetActive(true);
        PanelUILogin.gameObject.SetActive(false);
    }
    public void ShowUserInfo(string username)
    {
        userInfoPresenter.showUser(username);
    }
    public void LogoutUser()
    {
        PanelUILogin.gameObject.SetActive(true);
        PanelInfoUser.SetActive(false);
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


    // Start is called before the first frame update
    void Start()
    {
        userInfoPresenter = new PresenterUserInfo(this);
        PanelInfoUser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
