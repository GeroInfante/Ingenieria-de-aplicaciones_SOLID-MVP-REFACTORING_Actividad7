using System.Collections.Generic;
using UnityEngine;

public class PresenterListUsersInfo : PresenterShowUserInfoInPanel, IPresenterListOfAllUsers 
{
	IUIListOfAllUsersInfo listOfUserUI;
	IModelListOfAllUsernamesInLocalFiles modelListAllUser;
	public PresenterListUsersInfo(IUIListOfAllUsersInfo uiListAllUsers)
	{
		//Atributros de Clase abstracta
		userShowInfoUI = uiListAllUsers;

		//Atributos propios
		listOfUserUI = uiListAllUsers;
		modelListAllUser = new ModelListOfAllUsernamesInLocalFiles();
	}
	private void ShowAgentInPanel(Agent agent)
	{
		Persona person = agent.Persona;
		UnityEngine.Debug.Log("Nombre: " + person.Nombre);
		Sprite image = agent.Image;
		ShowAgentInuserInfoInterface(person, image);
	}
	private void ActiveOrDeactiveButtons()
	{
		IListPositionState positionState = modelListAllUser.GetPositionState();
		positionState.SetVisibilityToNextAndPreviousButtomsInUI(this);
	}

	public void GetFirstAgent()
	{
		Agent agent = modelListAllUser.GetFirstAgent();
		ShowAgentInPanel(agent);
		ActiveOrDeactiveButtons();
	}
	public void GetNextUser()
	{
		Agent agent = modelListAllUser.GetNextAgent();
		ShowAgentInPanel(agent);
		ActiveOrDeactiveButtons();
	}

	public void GetPreviousUser()
	{
		Agent agent = modelListAllUser.GetPreviousAgent();
		ShowAgentInPanel(agent);
		ActiveOrDeactiveButtons();
	}

	public void DeactivateNextButton()
	{
		listOfUserUI.DeactivateNextButton();
	}

	public void ActivateNextButton()
	{
		listOfUserUI.ActivateNextButton();
	}

	public void DeactivatePreviousButton()
	{
		listOfUserUI.DeactivatePreviousButton();
	}

	public void ActivatePreviousButton()
	{
		listOfUserUI.ActivatePreviousButton();
	}

} 