using System.IO;

public class LocalFileMaker : ILocalFileMaker
{
    private string PathJsonsFolder = "./Json";
    private IParser Parser;
    private ILocalFileService LocalFileService;

    public LocalFileMaker()
    {
        Parser = new ModelParser();
        LocalFileService = new LocalFilesService();
    }


    public void FlushAllLocalAgentsFiles()
    {
        foreach (string jsonDirectoryPath in Directory.EnumerateFiles(PathJsonsFolder))
        {
            if (IsAgent(jsonDirectoryPath))
            {
                File.Delete(jsonDirectoryPath);
            }
        }
    }
    private bool IsAgent(string jsonDirectory)
    {
        string username = Path.GetFileName(jsonDirectory);
        bool isAgent = !LocalFileService.CheckIfIsAdmin(username);
        return isAgent;
    }
    private string GetJsonTextWithPath(string jsonPath)
    {
        return File.ReadAllText(jsonPath);
    }

    public void MakeNewLocalJsonDirectory(string jsonString)
    {
        string jsonWithAgentRole = AddRoleAgentToJson(jsonString);
        string nameOfJsonFileToCreate = Parser.GetUsername(jsonWithAgentRole);
        CreateFileWithJson(nameOfJsonFileToCreate, jsonWithAgentRole);
    }

    private string AddRoleAgentToJson(string json)
    {
        return Parser.AddRoleAgentToJson(json);
    }

    private void CreateFileWithJson(string fileNameToSet, string json)
    {
        string path = PathJsonsFolder + "/" + fileNameToSet;
        StreamWriter escritor = new StreamWriter(path, false);
        escritor.WriteLine(json);
        escritor.Close();
    }
}