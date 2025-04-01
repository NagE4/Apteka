using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveGame(GameData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(json);
        }
        return null;
    }
}

[System.Serializable]
public class GameData
{
    public int money;
    public int currentDay;
}