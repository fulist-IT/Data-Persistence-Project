using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string nameOfPlayerRecord;
    public string nameOfPlayer;

    public int scoreMax = 0;
    public int score = 0;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Persistence.Instance.LoadBestPLayerScore();
    }

    private void Update()
    {
        //con questa riesco a salvare in scoreMax il punteggio massimo del giocatore durante una sessione di gioco
        ConfrontScores(); 
    }

    public void ConfrontScores()
    {
        if (score >= scoreMax)
        {
            scoreMax = score;
            nameOfPlayerRecord = nameOfPlayer; 
        }
    }




    [System.Serializable]
    class SaveData
    {
        public string nameOfPlayerRecord;
        public int scoreMax;
    }

    public void SaveBestPlayerScore()
    {
        SaveData data = new SaveData();
        data.nameOfPlayerRecord = nameOfPlayerRecord;
        data.scoreMax = scoreMax;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPLayerScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nameOfPlayerRecord = data.nameOfPlayerRecord;
            scoreMax = data.scoreMax;
        }
    }
}
