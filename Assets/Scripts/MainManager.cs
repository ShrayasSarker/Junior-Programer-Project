using UnityEngine;
using System.IO;
using System;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get;private set;}
    public Color TeamColor;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();

        //MainManager.Instance = null;
    }

    [System.Serializable]

    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        String json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        String path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            String json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
