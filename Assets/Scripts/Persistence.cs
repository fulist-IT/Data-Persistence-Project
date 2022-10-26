using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string nameOfPlayer;

    public int scoreMax = 0;
    public int score = 0;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //con questa riesco a salvare in scoreMax il punteggio massimo del giocatore durante una sessione di gioco
        ConfrontScores(); 
    }

    public void ConfrontScores()
    {
        if (score>=scoreMax)
        {
            scoreMax = score;
        }
    }
}
