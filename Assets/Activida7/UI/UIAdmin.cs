using UnityEngine;
using UnityEngine.UI;

public class UIAdmin : MonoBehaviour, IUIAdmin
{
    public Button AddNewAgentButton, ShowAllAgentsButton, LogoutButton;
    public GameObject PanelAdmin;
    public UILogin PanelUILogin;
    public UIListOfAllUsersInfo PanelListOfAllUsers;
    private IPresenterAdmin PresenterAdmin;

    void Start()
    {
        PanelAdmin.SetActive(false);
        PresenterAdmin = new PresenterAdmin();
    }

    public void ShowAllAgents()
    {
        PanelListOfAllUsers.ShowFirstUser();
        ChangeAdminPanelToAllUsersListPanel();
    }

    public void GenerateNewAgents()
    {
        PresenterAdmin.GenerateNewAgents();
    }
    
    public void Logout()
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
        PanelListOfAllUsers.gameObject.SetActive(true);
        PanelAdmin.SetActive(false);
    }


    void Update()
    {
        
    }
}