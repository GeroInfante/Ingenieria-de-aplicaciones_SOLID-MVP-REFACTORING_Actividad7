using System.IO;

public class LocalFileMaker : ILocalFileMaker
{
    private string PathJsonsFolder = "./Json/";
    private IParser parser;

    public LocalFileMaker()
    {
        parser = new ModelParser();
    }

    public void MakeNewLocalJsonDirectory(string jsonString)
    {
        string jsonWithAgentRole = AddRoleAgentToJson(jsonString);
        string nameOfJsonFileToCreate = parser.GetUsername(jsonWithAgentRole);
        CreateFileWithJson(nameOfJsonFileToCreate, jsonWithAgentRole);
    }

    private string AddRoleAgentToJson(string json)
    {
        return parser.AddRoleAgentToJson(json);
    }

    private void CreateFileWithJson(string fileNameToSet, string json)
    {
        string path = PathJsonsFolder + "/" + fileNameToSet;
        StreamWriter escritor = new StreamWriter(path, false);
        escritor.WriteLine(json);
        escritor.Close();
    }
}