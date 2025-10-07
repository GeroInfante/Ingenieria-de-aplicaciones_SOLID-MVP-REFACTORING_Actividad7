using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UIUserInfoLogged : UIShowUserInfoInPanel, IUIUserInfoLogged
{
    public IPresenterUserInfoLogged userInfoPresenter;

    public void ShowuserInfoPanel()
    {
        userInformationPanel.SetActive(true);
        PreviousPanel.SetActive(false);
    }
    public void ShowUserInfo(string username)
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
