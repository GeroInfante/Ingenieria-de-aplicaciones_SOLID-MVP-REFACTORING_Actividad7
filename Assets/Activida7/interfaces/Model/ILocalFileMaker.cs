using UnityEngine;
public interface ILocalFileMaker
{
    void MakeNewLocalJsonDirectory(string json);
    void SaveImageTextureWithUsername(Texture2D texture, string username);
    void FlushAll();
}