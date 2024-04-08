using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;


public class LandingPageControlle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewCasualGame () 
    {
        SceneManager.LoadScene("NewCasualGame");
    }

    public void NewRankedGame()
    {
        SceneManager.LoadScene("NewRankedGame");
    }

    public void Database()
    {
        SceneManager.LoadScene("DecksDatabase");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void NewDeck()
    {
        SceneManager.LoadScene("NewDeck");
    }

    public void Return()
    {
        SceneManager.LoadScene("LandingPage");
    }
}
