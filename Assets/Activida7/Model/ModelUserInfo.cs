using UnityEngine;
using System.Threading.Tasks;

public class ModelUserInfo : IModelUserInfo
{
    public ILocalFileService localFiles;
    public IApiManager apiManager;

    public ModelUserInfo()
    {
        localFiles = new LocalFilesService();
        apiManager = new APIManager_act6();
    }
    public Persona GetAgentWithUsername(string username)
    {
        Persona agentToReturn = localFiles.GetAgent(username);

        return agentToReturn;
    }
    public Sprite GetAgentImage(string username)
    {
        Texture2D texture = localFiles.GetImageTextureWithUsername(username);

        return Sprite.Create(
            texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f)
        );
    }

}
