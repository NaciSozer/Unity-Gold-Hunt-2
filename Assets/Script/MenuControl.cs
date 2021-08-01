using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{

    public Text HighScore;


    void Start()
    {

       int HighScor = PlayerPrefs.GetInt("Save");

        HighScore.text = "" + HighScor;
            
    }

   
}
