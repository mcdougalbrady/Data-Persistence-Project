using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] InputField playerNameField;
    [SerializeField] TextMeshProUGUI highScoreText;
    private DataPersistenceManager dataManager;

    private void Start()
    {
        dataManager = DataPersistenceManager.Instance;
        dataManager.LoadHighScoreData();
        if(dataManager.topPlayerName != null && dataManager.highScore != 0)
        {
            highScoreText.text = "Top Score : " + dataManager.topPlayerName + " : " + dataManager.highScore;
        }
    }

    public void SavePlayerName()
    {
        dataManager.playerName = playerNameField.text;
    }

    public void StartGame()
    {
        SavePlayerName();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        dataManager.SaveHighScoreData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
