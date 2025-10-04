public class ModelAdmin : IModelAdmin
{
    private LocalFileMaker LocalFileMaker;
    private APIManager_act6 ApiManager;

    public ModelAdmin()
    {
        LocalFileMaker = new LocalFileMaker();
        ApiManager = new APIManager_act6();
        
    }
    public void GenerateNewAgents()
    {
        LocalFileMaker.FlushAllLocalAgentsFiles();
        UnityEngine.Debug.Log("Termina Model");
    }
}