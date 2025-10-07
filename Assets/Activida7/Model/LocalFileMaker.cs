using System.IO;
using UnityEngine;

public class LocalFileMaker : ILocalFileMaker
{
    private string PathJsonsFolder = "./Json";
    private string PathImageFolder = "./Image";
    private IParser Parser;
    private ILocalFileService LocalFileService;

    public LocalFileMaker()
    {
        Parser = new ModelParser();
        LocalFileService = new LocalFilesService();
    }

    public void FlushAll()
    {
        FlushAllLocalAgentsFiles();
        FlushAllLocalImagesFiles();
    }
    private void FlushAllLocalAgentsFiles()
    {
        foreach (string jsonDirectoryPath in Directory.EnumerateFiles(PathJsonsFolder))
        {
            if (IsAgent(jsonDirectoryPath))
            {
                File.Delete(jsonDirectoryPath);
            }
        }
    }
    private void FlushAllLocalImagesFiles()
    {
        foreach (string imageDirectoryPath in Directory.EnumerateFiles(PathImageFolder))
        {
            File.Delete(imageDirectoryPath); 
        }
    }
    private bool IsAgent(string jsonDirectory)
    {
        string username = Path.GetFileName(jsonDirectory);
        bool isAgent = !LocalFileService.CheckIfIsAdmin(username);
        return isAgent;
    }

    public void MakeNewLocalJsonDirectory(string jsonString)
    {
        string jsonWithAgentRole = AddRoleAgentToJson(jsonString);
        string nameOfJsonFileToCreate = Parser.GetUsername(jsonWithAgentRole);
        CreateFileWithJson(nameOfJsonFileToCreate, jsonWithAgentRole);
    }
    public void SaveImageTextureWithUsername(Texture2D texture, string username)
    {
        byte[] bytes = texture.EncodeToPNG();
        string path = PathImageFolder+"/"+ username + ".png";
        File.WriteAllBytes(path, bytes);
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