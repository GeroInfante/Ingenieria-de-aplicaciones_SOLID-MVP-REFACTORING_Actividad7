using UnityEngine;

public abstract class PresenterShowUserInfoInPanel 
{
    protected UIShowUserInfoInPanel userShowInfoUI;
    public void ShowAgentInuserInfoInterface(Persona agentToShow, Sprite image)
    {
        userShowInfoUI.showName(agentToShow.Nombre);
        userShowInfoUI.showLastName(agentToShow.Apellido);
        userShowInfoUI.showAge(agentToShow.Edad);
        userShowInfoUI.showPhone(agentToShow.Telefono);
        userShowInfoUI.showAddress(agentToShow.Direccion);
        userShowInfoUI.showEmail(agentToShow.Email);
        userShowInfoUI.showImage(image);
    }

}