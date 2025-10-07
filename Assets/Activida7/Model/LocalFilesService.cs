using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class LocalFilesService : ILocalFileService
{
    const String jsonsPathfolder = "./Json";
    const String imagePathfolder = "./Image";
    public IParser parser;
    private string ADMIN_ROLE = "admin";

    public LocalFilesService()
    {
        parser = new ModelParser();
    }

    public Texture2D GetImageTextureWithUsername(string username)
    {
        //Busco imagen que el nombre corresponde con el username que me pasaron
        string imagePath = Path.Combine(imagePathfolder, username+".png");
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imageBytes);
        return texture;

    }

    public bool CheckIfUserExist(string username)
    {
        bool userNotFound = true;
        bool userFound = false;
        string userJsonpath, currentUser;


        IEnumerable<string> usersJsons = Directory.EnumerateFiles(jsonsPathfolder);
        IEnumerator<string> iteratorUserJsons = usersJsons.GetEnumerator();

        while (userNotFound && iteratorUserJsons.MoveNext())
        {
            userJsonpath = iteratorUserJsons.Current;
            currentUser = Path.GetFileName(userJsonpath);
            if (username.Equals(currentUser))
                userNotFound = false;
        }
        userFound = !userNotFound;
        Debug.Log("User foud: " + userFound);
        return userFound;
    }
    public bool CheckIfIsAdmin(string username)
    {
        string json = GetJsonTextwithUsername(username);
        string roleOfUser = parser.GetRole(json);
        bool isAdmin = ADMIN_ROLE == roleOfUser;
        return isAdmin;
    }

    public bool CheckIfPasswordIsCorrect(string username, string password)
    {
        string json = GetJsonTextwithUsername(username);
        string realPassword = parser.getPassword(json);
        bool passwordIscorrect = realPassword.Equals(password);
        Debug.Log("Password Correct: " + passwordIscorrect);
        return passwordIscorrect;
    }
    public Persona GetAgent(string username)
    {
        string json = GetJsonTextwithUsername(username);
        Persona agentOrdered = parser.getUser(json);
        return agentOrdered;
    }

    public List<string> GetAllUsernamesOfAgents()
    {
        List<string> listWithAllUsernames = new List<string>();
        foreach (string jsonDirectoryPath in Directory.EnumerateFiles(jsonsPathfolder))
        {
            string username = Path.GetFileName(jsonDirectoryPath);
            if (!CheckIfIsAdmin(username))
            {
                listWithAllUsernames.Add(username);
            }
        }
        return listWithAllUsernames;
    }
    private string GetJsonTextwithUsername(string username)
    {
        string usernameJsonPath = GetUserJsonPath(username);
        string json = File.ReadAllText(usernameJsonPath);
        return json;
    }
    private string GetUserJsonPath(string username)
    {
        string userJsonpath = "";
        string currentUser;
        bool userNotFound = true;

        IEnumerable<string> usersJsons = Directory.EnumerateFiles(jsonsPathfolder);
        IEnumerator<string> iteratorUserJsons = usersJsons.GetEnumerator();

        while (userNotFound && iteratorUserJsons.MoveNext())
        {
            userJsonpath = iteratorUserJsons.Current;
            currentUser = Path.GetFileName(userJsonpath);
            if (username.Equals(currentUser))
                userNotFound = false;
        }
        return userJsonpath;
    }
}
