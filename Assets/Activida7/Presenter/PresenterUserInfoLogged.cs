using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PresenterUserInfoLogged : PresenterShowUserInfoInPanel, IPresenterUserInfoLogged
{
    public IUIUserInfoLogged userInfoUI;
    protected IModelUserInfo userInfoModel;

    public PresenterUserInfoLogged(IUIUserInfoLogged ui)
    {
        userInfoUI = ui;
        userShowInfoUI = ui;
        userInfoModel = new ModelUserInfo();
    }
    public void showUser(string username)
    {
        Persona agent = GetAgent(username);
        Sprite image = GetAgentImage(username);
        ShowAgentInuserInfoInterface(agent, image);
        userInfoUI.ShowuserInfoPanel();
    }


    private Persona GetAgent(string username)
    {
        Persona agent = userInfoModel.GetAgentWithUsername(username);
        return agent;
    }
    private Sprite GetAgentImage(string username)
    {
        Sprite agentSprite = userInfoModel.GetAgentImage(username);
        return agentSprite;
    }


}
