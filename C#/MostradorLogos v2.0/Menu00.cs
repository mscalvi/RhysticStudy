using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu00 : MonoBehaviour
{
    public Button bComecarBingo;

    public Button bSair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComecarBingo ()
    {
        SceneManager.LoadScene ("Menu01");
    }

    public void Sair ()
    {
        Application.Quit ();
    }
}
