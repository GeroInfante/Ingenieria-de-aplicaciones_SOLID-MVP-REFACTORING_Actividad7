
using UnityEngine;
using System.Threading.Tasks;

public interface IModelUserInfo
{
    Persona GetAgentWithUsername(string username);
    Sprite GetAgentImage(string imageURL);
}
