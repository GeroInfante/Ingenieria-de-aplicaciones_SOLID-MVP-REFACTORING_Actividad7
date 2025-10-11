
using UnityEngine;
using System.Collections.Generic;

public interface ILocalFileService
{
    Persona GetAgent(string username);
    bool CheckIfPasswordIsCorrect(string username, string password);
    bool CheckIfUserExist(string username);
    bool CheckIfIsAdmin(string username);
    Texture2D GetImageTextureWithUsername(string username);
    List<string> GetAllUsernamesOfAgents();
}
