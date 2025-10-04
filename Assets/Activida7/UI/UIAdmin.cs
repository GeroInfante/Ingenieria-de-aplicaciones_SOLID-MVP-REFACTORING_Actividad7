using UnityEngine;
using UnityEngine.UI;

public class UIAdmin : MonoBehaviour, IUIAdmin
{
    public Button AddNewAgentButton, ShowAllAgentsButton, LogoutButton;
    public GameObject PanelAdmin;
    public UILogin PanelUILogin;

    void Start()
    {
        PanelAdmin.SetActive(false);
    }

    public void ShowAllAgents()
    {
        
    }
    
    public void GenerateNewAgents()
    {
        
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



    void Update()
    {
        
    }
}