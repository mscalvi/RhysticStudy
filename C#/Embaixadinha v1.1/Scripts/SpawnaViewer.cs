using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaViewer : MonoBehaviour
{
    public GameObject viewerPrefab; 
    public static bool ViewerTela;

    void Start ()
    {
        ViewerTela = false;
    }

    void Update()
    {
        //Dia 003
        Debug.Log (ControleFase.NumeroFase);
        if(ViewerTela == false && ControleFase.NumeroFase == 3 && MarcadorPontos.ComecaFase == true)
        {
            Vector3 randomSpawnPosition = new Vector3 (Random.Range(-2, 2), Random.Range(-2, 5), -1);
            Instantiate (viewerPrefab, randomSpawnPosition, Quaternion.identity);
            StartCoroutine (SumirViewer3());
        }

        //Dia 004 e 005
        if(ViewerTela == false && ControleFase.NumeroFase == 4 && MarcadorPontos.ComecaFase == true)
        {
            Debug.Log ("Entrei na fase 4");
            Vector3 randomSpawnPosition = new Vector3 (Random.Range(-2, 2), Random.Range(-2, 5), -1);
            Instantiate (viewerPrefab, randomSpawnPosition, Quaternion.identity);
            StartCoroutine (SumirViewer4());
        }

        if(ViewerTela == false && ControleFase.NumeroFase == 5 && MarcadorPontos.ComecaFase == true)
        {
            Debug.Log ("Entrei na fase 5");
            Vector3 randomSpawnPosition = new Vector3 (Random.Range(-2, 2), Random.Range(-2, 5), -1);
            Instantiate (viewerPrefab, randomSpawnPosition, Quaternion.identity);
            StartCoroutine (SumirViewer4());
        }

        //Dia 006
        if(ViewerTela == false && ControleFase.NumeroFase == 6 && MarcadorPontos.ComecaFase == true)
        {
            Vector3 randomSpawnPosition = new Vector3 (Random.Range(-2, 2), Random.Range(-2, 5), -1);
            Instantiate (viewerPrefab, randomSpawnPosition, Quaternion.identity);
            StartCoroutine (SumirViewer6());
        }
    }

    IEnumerator SumirViewer3()
    {
        ViewerTela = true;
        yield return new WaitForSeconds(3);
        Destroy (GameObject.FindWithTag("Viewer"));
        yield return new WaitForSeconds(10);
        ViewerTela = false;
    }

    IEnumerator SumirViewer4()
    {
        ViewerTela = true;
        yield return new WaitForSeconds(3);
        Destroy (GameObject.FindWithTag("Viewer"));
        yield return new WaitForSeconds(4);
        ViewerTela = false;
    }

    IEnumerator SumirViewer6()
    {
        ViewerTela = true;
        yield return new WaitForSeconds(4);
        Destroy (GameObject.FindWithTag("Viewer"));
        yield return new WaitForSeconds(1);
        ViewerTela = false;
    }
}
