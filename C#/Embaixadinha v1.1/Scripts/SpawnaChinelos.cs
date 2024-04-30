using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnaChinelos : MonoBehaviour
{
    public GameObject ChineloVoador; 
    public static bool ChineloTela = false;

    void Update()
    {
        Debug.Log("ligado");
        if(ChineloTela == false && ControleFase.NumeroFase == 4 && MarcadorPontos.ComecaFase == true)
        {
            Debug.Log("Alo");
            ChineloTela = true;
            Vector3 randomSpawnPosition = new Vector3 (2, Random.Range(-2, 6), 1);
            Instantiate (ChineloVoador, randomSpawnPosition, Quaternion.identity);
        }
    }
}