using System.Collections.Generic;
using UnityEngine;

public class ModelListOfAllUsernamesInLocalFiles : IModelListOfAllUsernamesInLocalFiles
{
    private List<string> usernamesList;
    private ILocalFileService localFileService;
    private IModelUserInfo modelUserInfo;
    private int position;
    private const int FIRST_POSITION = 0;

    public ModelListOfAllUsernamesInLocalFiles()
    {
        localFileService = new LocalFilesService();
        modelUserInfo = new ModelUserInfo();
    }
    private void IncressePosition()
    {
        position++;
    }
    private void DecreasePosition()
    {
        position--;
    }
    private string GetUsernameOfActualPosition()
    {
        string username = usernamesList[position];
        return username;
    }
    public Agent GetFirstAgent()
    {
        InitializateListAndPosition();
        string username = GetUsernameOfActualPosition();
        Agent agent = GetAgentByUsername(username);
        return agent;
    }
    private void InitializateListAndPosition()
    {
        GetListOfUsersInLocalFiles();
        position = FIRST_POSITION;
    }
    private void GetListOfUsersInLocalFiles()
    {
        usernamesList = localFileService.GetAllUsernamesOfAgents();
    }
    private Agent GetAgentByUsername(string username)
    {
        Persona persona = modelUserInfo.GetAgentWithUsername(username);
        Sprite image = modelUserInfo.GetAgentImage(username);
        Agent agent = new Agent();
        agent.Persona = persona;
        agent.Image = image;
        return agent;
    }
    public Agent GetNextAgent()
    {
        IncressePosition();
        string username = GetUsernameOfActualPosition();
        Agent agent = GetAgentByUsername(username);
        return agent;
    }
    public Agent GetPreviousAgent()
    {
        DecreasePosition();
        string username = GetUsernameOfActualPosition();
        Agent agent = GetAgentByUsername(username);
        return agent;
    }

    public IListPositionState GetPositionState()
    {
        if (position == FIRST_POSITION)
        {
            return new FirstPositionState();
        }
        if (position == lastPosition())
        {
            return new LastPositionState();
        }
        return new IntermediatePositionState();

    }
    private int lastPosition()
    {
        return usernamesList.Count - 1;
    }

}