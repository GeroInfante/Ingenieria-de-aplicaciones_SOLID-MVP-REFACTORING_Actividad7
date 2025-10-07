using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
// Add the following using if you are working in Unity
using UnityEngine;

public class ModelAdmin : IModelAdmin
{
    private LocalFileMaker LocalFileMaker;
    private LocalFilesService localFilesService;
    private IApiManager ApiManager;

    public ModelAdmin()
    {
        LocalFileMaker = new LocalFileMaker();
        ApiManager = new APIManager_act6();
        localFilesService = new LocalFilesService();
    }
    public async Task GenerateNewAgents()
    {
        FlushLocalAgentsFiles();
        await GetNewAgentsAndCreateNewJsonsFile();
        List<string> listWithAllUsernamesInLocalFiles = GetAllUsernamesOfAgents();
        await GetAllImagesFromNewAgents(listWithAllUsernamesInLocalFiles);
    }

    private List<string> GetAllUsernamesOfAgents()
    {
        return localFilesService.GetAllUsernamesOfAgents();
    }
    private void FlushLocalAgentsFiles()
    {
        LocalFileMaker.FlushAll();
    }
    private async Task GetNewAgentsAndCreateNewJsonsFile()
    {
        string jsonFromAPi;
        for (int i = 0; i < 10; i++)
        {
            jsonFromAPi = await AskApiForNewJson();
            LocalFileMaker.MakeNewLocalJsonDirectory(jsonFromAPi);

        }
    }
    private async Task GetAllImagesFromNewAgents(List<string> istWithAllUsernamesInLocalFiles)
    {
        Persona agent;
        foreach (string username in istWithAllUsernamesInLocalFiles)
        {
            agent = localFilesService.GetAgent(username);
            string imageURL = agent.Imagen;
            Texture2D texture = await ApiManager.GetTexture(imageURL);
            if (texture != null)
            {
                LocalFileMaker.SaveImageTextureWithUsername(texture, username);
            }

        }
    }

    private async Task<string> AskApiForNewJson()
    {
        return await ApiManager.GetUserJson();
    }
}