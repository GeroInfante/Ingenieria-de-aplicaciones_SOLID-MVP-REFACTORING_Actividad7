using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PresenterUserInfoLogged : IPresenterUserInfoLogged
{
    public UIUserInfoLogged userInfoUI;
    public IModelUserInfo userInfoModel;

    public PresenterUserInfoLogged(UIUserInfoLogged ui)
    {
        userInfoUI = ui;
        userInfoModel = new ModelUserInfo();
    }
    public void showUser(string username)
    {
        Persona agent = userInfoModel.GetAgentWithUsername(username);
        Sprite image = userInfoModel.GetAgentImage(username);
        showAgentInuserInfoInterface(agent, image);
        userInfoUI.ShowuserInfoPanel();
        
    }

    private void showAgentInuserInfoInterface(Persona agentToShow, Sprite image)
    {
        userInfoUI.showName(agentToShow.Nombre);
        userInfoUI.showLastName(agentToShow.Apellido);
        userInfoUI.showAge(agentToShow.Edad);
        userInfoUI.showPhone(agentToShow.Telefono);
        Debug.Log(agentToShow.Telefono);
        userInfoUI.showAddress(agentToShow.Direccion);
        userInfoUI.showEmail(agentToShow.Email);
        userInfoUI.showImage(image);
    }

}
