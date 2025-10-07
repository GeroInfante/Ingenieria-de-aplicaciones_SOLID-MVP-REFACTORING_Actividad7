using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour, IUILogin
{
    public Button togglePasswordVisibility, login;
    public TMP_InputField username, password;

    public TextMeshProUGUI userError, passwordError;
    public GameObject PanelUILogin;
    private Color VISIBLE = Color.green;
    private Color NOTVISIBLE = Color.red;



    private IPresenterLogin loginPresenter;
    public UIUserInfoLogged panelUserInfo;
    public UIAdmin panelAdmin;
    void Start()
    {
        loginPresenter = new PresenterLogin(this);
        ChangeTogglePasswordVisibilityColors(NOTVISIBLE);
        userError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
        PanelUILogin.SetActive(true);
    }

    public void TogglePasswordVisibility()
    {
        bool isVisible = getPasswordVisibility();
        if (isVisible)
        {
            password.contentType = TMP_InputField.ContentType.Password;
            ChangeTogglePasswordVisibilityColors(NOTVISIBLE);
        }
        else
        {
            password.contentType = TMP_InputField.ContentType.Standard;
            ChangeTogglePasswordVisibilityColors(VISIBLE);
        }
        password.ForceLabelUpdate();
    }
    private bool getPasswordVisibility()
    {
        bool isVisible = false;
        if (password.contentType == TMP_InputField.ContentType.Standard)
            isVisible = true;
        return isVisible;
    }

    private void ChangeTogglePasswordVisibilityColors(Color color)
    {
        togglePasswordVisibility.image.color = color;
    }

    public void LoginUser()
    {
        clearErrors();
        loginPresenter.Login(username.text, password.text);
        Debug.Log("Intentando loguear a " + username.text);
        resetAllInputs();
    }
    public void showUser()
    {
        string usernameToshow = username.text;
        panelUserInfo.ShowUserInfo(usernameToshow);
    }

    public void ShowAdmin()
    {
        panelAdmin.gameObject.SetActive(true);
        PanelUILogin.SetActive(false);
    }

    public void showUserNotFound()
    {
        userError.gameObject.SetActive(true);
    }
    public void showIncorrectPassword()
    {
        passwordError.gameObject.SetActive(true);
    }

    private void resetAllInputs()
    {
        username.text = "";
        password.text = "";
    }
    private void clearErrors()
    {
        userError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}