using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class GameDataViewer : MonoBehaviour
{
    public static GameDataViewer instance;
    public GameData data;
    private void Awake()
    {
        instance= this;
        data = GameData.instance;
        Load();
    }
    [ContextMenu("Save To Json Data")]
    public void Save()
    {
        string jsonData = JsonUtility.ToJson(this, true);
        string path = Path.Combine(Application.dataPath, "UserData.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("Load From Json Data")]
    public void Load()
    {
        string path = Path.Combine(Application.dataPath, "UserData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(jsonData, instance);
        }
    }
    private void OnDisable()
    {
        Save();
    }
}
