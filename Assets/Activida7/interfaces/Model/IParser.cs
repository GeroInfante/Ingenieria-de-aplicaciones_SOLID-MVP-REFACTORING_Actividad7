

public interface IParser
{
    string getPassword(string json);
    string GetUsername(string json);
    string GetRole(string json);
    Persona getUser(string Json);
    string AddRoleAgentToJson(string json);
}
