using UnityEngine;
using UnityEngine.UI;

public class UIAdmin : IUIAdmin
{
    public Button AddNewAgentButton, ShowAllAgentsButton, LogoutButton;
    public GameObject PanelAdmin;
    public IUILogin PanelUILogin;
    public IUIListOfAllUsersInfo PanelListOfAllUsers;
    private IPresenterAdmin PresenterAdmin;

    void Start()
    {
        PanelAdmin.SetActive(false);
        PresenterAdmin = new PresenterAdmin();
    }

    public override void ShowAllAgents()
    {
        PanelListOfAllUsers.ShowFirstUser();
        ChangeAdminPanelToAllUsersListPanel();
    }

    public override void GenerateNewAgents()
    {
        PresenterAdmin.GenerateNewAgents();
    }
    
    public override void Logout()
    {
        ChangeAdminPanelToLoginPanel();
    }
    private void ChangeAdminPanelToLoginPanel()
    {
        PanelUILogin.gameObject.SetActive(true);
        PanelAdmin.SetActive(false);
    }
    private void ChangeAdminPanelToAllUsersListPanel()
    {
        PanelListOfAllUsers.GetGameOBject().SetActive(true);
        PanelAdmin.SetActive(false);
    }


    void Update()
    {
        
    }
}