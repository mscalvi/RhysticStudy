using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FimJogo : MonoBehaviour
{
    public static bool PerdeuVida;
    public static bool JaPerdeuVida;
    // Start is called before the first frame update

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("BolaPrincipal"))
        {
            if(PerdeuVida == false && MarcadorPontos.PrimeiroChute == false && MarcadorPontos.FaseConcluida == false && MarcadorPontos.ComecaFase == true)
            {
                if (PlayerPrefs.GetInt("VidasRestantes") <= 1)
                {
                    StartCoroutine(JogoTerminando());
                    PerdeuVida = true;
                    other.gameObject.GetComponent<ComportBola>().TerminarJogo();
                } else {
                    MarcadorPontos.VidasRestantes -= 1;
                    MarcadorPontos.ComecaFase = false;
                    MarcadorPontos.PontosTotalValor = PlayerPrefs.GetInt("PontosComecoFase");
                    PlayerPrefs.SetInt("VidasRestantes", MarcadorPontos.VidasRestantes);
                    PerdeuVida = true;
                    JaPerdeuVida = true;
                    other.gameObject.GetComponent<ComportBola>().RePosicaoBola();
                    StartCoroutine(JogoTerminando());
                }
            }
        }
    }

    IEnumerator JogoTerminando ()
    {
        yield return new WaitForSeconds(1);
    }
}
