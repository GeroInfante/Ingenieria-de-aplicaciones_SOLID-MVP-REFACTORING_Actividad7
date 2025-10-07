using System.Diagnostics;
using Newtonsoft.Json.Linq;


public class ModelParser : IParser
{
    public bool IsValidJson(string json)
    {
        JObject jsonObject = JObject.Parse(json);
        return jsonObject["results"] != null && jsonObject["results"].HasValues;
    }
    public string getPassword(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        var personaJson = objetoJson["results"][0];
        string password = (string)personaJson["login"]["password"];
        return password;
    }

    public string GetUsername(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        var personaJson = objetoJson["results"][0];
        string username = (string)personaJson["login"]["username"];
        return username;
    }
    public string GetRole(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        var personaJson = objetoJson["results"][0];
        string role = (string)personaJson["login"]["role"];
        return role;    
    }
    public string GetAgentImageURL(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        var personaJson = objetoJson["results"][0];
        string image = (string)personaJson["picture"]["large"];
        return image;    
    }

    public Persona getUser(string Json)
    {
        JObject objetoJson = JObject.Parse(Json);


        var personaJson = objetoJson["results"][0];
        Persona persona = new Persona();
        persona.Nombre = (string)personaJson["name"]["first"];
        persona.Apellido = (string)personaJson["name"]["last"];
        persona.Edad = (string)personaJson["dob"]["age"];
        persona.Telefono = (string)personaJson["phone"];
        persona.Direccion = (string)personaJson["location"]["street"]["name"] + " " + (string)personaJson["location"]["street"]["number"];
        persona.Email = (string)personaJson["email"];
        persona.Imagen = (string)personaJson["picture"]["large"];

        return persona;
    }

    public string AddRoleAgentToJson(string json)
    {
        JObject objetoJson = JObject.Parse(json);
        objetoJson["results"][0]["login"]["role"] = "agent";
        return objetoJson.ToString();
    }
}
