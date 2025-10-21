using UnityEngine;

public abstract class IUIAdmin: MonoBehaviour
{
    public abstract void ShowAllAgents();
    public abstract void GenerateNewAgents();
    public abstract void Logout();
    public abstract void TellToListTOShowFirstUser();
}
