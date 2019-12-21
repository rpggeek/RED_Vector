using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public Text score;
    void Start()
    {
        
        score.text=""+ PlayerPrefs.GetInt("score");
    }
    void Update()
    {
       
    }
    public void tiklandi()
    {
        Application.LoadLevel("play");
    }
}
