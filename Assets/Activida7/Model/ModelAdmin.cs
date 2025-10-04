using System.Threading.Tasks;

public class ModelAdmin : IModelAdmin
{
    private LocalFileMaker LocalFileMaker;
    private IApiManager ApiManager;

    public ModelAdmin()
    {
        LocalFileMaker = new LocalFileMaker();
        ApiManager = new APIManager_act6();

    }
    public async Task GenerateNewAgents()
    {
        FlushLocalAgentsFiles();
        await GetNewAgentsAndCreateNewJsonsFile();
    }
    private void FlushLocalAgentsFiles()
    {
        LocalFileMaker.FlushAllLocalAgentsFiles();
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
    private async Task<string> AskApiForNewJson()
    {
        return await ApiManager.GetUserJson();
    }
}