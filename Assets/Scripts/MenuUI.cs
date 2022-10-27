using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI nameToSave;

    public TextMeshProUGUI menuRecordText;

    //private void Awake()
    //{
        
    //}


    //Update necessario per aggiornare il nome del giocatore digitato nella casella di input durante il runtime
    private void Update()
    {    
        menuRecordText.text = $"Record:  {Persistence.Instance.nameOfPlayerRecord}: {Persistence.Instance.scoreMax}";

        DigitedNamePlayer();
    }

    public void DigitedNamePlayer()
    {
        Persistence.Instance.nameOfPlayer = nameToSave.text;
    }



    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    

    
}
