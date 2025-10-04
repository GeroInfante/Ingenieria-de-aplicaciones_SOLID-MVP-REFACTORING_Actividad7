using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager_act6 :IApiManager
{
    private IParser Parser;
    public APIManager_act6()
    {
        Parser = new ModelParser();
    }
    public async Task<Texture2D> GetTexture(string url)
    {
        bool exito = false;
        Texture2D texture = null;

        while (!exito)
        {
            using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
            {
                var asyncOp = www.SendWebRequest();

                while (!asyncOp.isDone) // espera sin bloquear
                    await Task.Yield();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                    exito = true;
                }
                else
                {
                    Debug.LogWarning("Error al descargar la imagen: " + www.error + ", reintentando...");
                    await Task.Delay(1000); // espera 1s antes de reintentar
                }
            }
        }
        Debug.Log("Imagen descargada correctamente");

        return texture;
    }

   public async Task<string> GetUserJson()
    {
        bool exito = false;
        string jsonCrudo = null;

        while (!exito)
        {
            using (UnityWebRequest www = UnityWebRequest.Get("https://randomuser.me/api/"))
            {
                var operation = www.SendWebRequest();

                // Espera asincrónica hasta que termine la descarga
                while (!operation.isDone)
                    await Task.Yield(); // Cede el hilo al resto mientras espera

                if (www.result == UnityWebRequest.Result.Success)
                {
                    jsonCrudo = www.downloadHandler.text;

                    if (Parser.IsValidJson(jsonCrudo))
                    {
                        exito = true;
                    }
                    else
                    {
                        Debug.LogWarning("JSON inválido, reintentando...");
                        await Task.Delay(1000); // Espera 1 segundo antes de reintentar
                    }
                }
                else
                {
                    Debug.LogWarning("Error en la API: " + www.error + ", reintentando...");
                    await Task.Delay(1000); // Espera 1 segundo antes de reintentar
                }
            }
        }

        return jsonCrudo;
    }
}

