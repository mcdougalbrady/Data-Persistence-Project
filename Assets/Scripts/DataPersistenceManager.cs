using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance;
    public string playerName;
    public string topPlayerName;
    public int highScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class SaveData
    {
        public string topPlayerName;
        public int highScore;
    }

    public void SaveHighScoreData()
    {
        SaveData data = new SaveData();
        data.topPlayerName = this.playerName;
        data.highScore = this.highScore;

        string json = JsonUtility.ToJson(data);
        string filePath = Application.persistentDataPath + "/highScoreData.txt";
        File.WriteAllText(filePath, json);
    }

    public void LoadHighScoreData()
    {
        string filePath = Application.persistentDataPath + "/highScoreData.txt";
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.topPlayerName = data.topPlayerName;
            this.highScore = data.highScore;
        }
    }

}
