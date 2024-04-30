using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AreaMouse : MonoBehaviour
{
    public static bool LiberaRotacao;

    // Start is called before the first frame update
    void Start()
    {
        LiberaRotacao = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Liberar a Rotacao
    public void OnMouseEnter()
    {
        LiberaRotacao = true;
    }

    public void OnMouseExit()
    {
        LiberaRotacao = false;
    }
}
