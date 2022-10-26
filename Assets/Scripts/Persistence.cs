using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;

    public string nameOfPlayer;
    public int score;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
