using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControleFase : MonoBehaviour
{
    public static int NumeroFase;
    public static string UltimaFaseCod;
    public TextMeshProUGUI TextFinal;
    public TextMeshProUGUI FaseAtual;

    // Start is called before the first frame update
    void Start()
    {
        TextFinal.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (NumeroFase)
        {
            case 1:
                UltimaFaseCod = "Dia001";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia001 ();
                break;
            case 2:
                UltimaFaseCod = "Dia002";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia002 ();
                break;
            case 3:
                UltimaFaseCod = "Dia003";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia003 ();
                break;
            case 4:
                UltimaFaseCod = "Dia004";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia004 ();
                break;
            case 5:
                UltimaFaseCod = "Dia005";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia005 ();
                break;
            case 6:
                UltimaFaseCod = "Dia006";
                PlayerPrefs.SetInt("NumeroFase", NumeroFase);
                ContadorFases ();
                FimDia006 ();
                break;
            default:
                break;
        }
    }

    //Contador de Fases
    public void ContadorFases ()
    {
        FaseAtual.text = ("Dia "+ NumeroFase); 
    }

    //Fim de Fase 1
    public void FimDia001 (){
        if (MarcadorPontos.PontosFaseValor == 20)
        {
            MarcadorPontos.FaseConcluida = true;
            StartCoroutine (EsperaDia001 ());
        }
    }

    IEnumerator EsperaDia001()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Sucesso! Hora de Descansar!";
        yield return new WaitForSeconds(3);
        NumeroFase = 2;
        SceneManager.LoadScene ("Dia002");
    }

    //Fim de Fase 2
    public void FimDia002 (){
        if(MarcadorPontos.PontosFaseValor == 20)
        {
            MarcadorPontos.FaseConcluida = true;
            StartCoroutine (EsperaDia002 ());
        }
    }

    IEnumerator EsperaDia002()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Sucesso! Agora é só aguardar ansioso.";
        yield return new WaitForSeconds(3);
        NumeroFase = 3;
        SceneManager.LoadScene ("Dia003");
    }

    //Fim de Fase 3
    public void FimDia003 (){
        if(MarcadorPontos.PontosFaseValor == 10)
        {
            MarcadorPontos.FaseConcluida = true;
            StartCoroutine (EsperaDia003 ());
        }
    }

    IEnumerator EsperaDia003()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Sua mãe te viu! Melhor desviar das chinelas voadoras.";
        yield return new WaitForSeconds(3);
        NumeroFase = 4;
        SceneManager.LoadScene ("Dia004");
    }

    //Fim de Fase 4
    public void FimDia004 (){
        if(MarcadorPontos.PontosFaseValor == 20)
        {
            MarcadorPontos.FaseConcluida = true;
            StartCoroutine (EsperaDia004 ());
        }
    }

    IEnumerator EsperaDia004()
    {
        TextFinal.enabled = true;
        TextFinal.text = "A emoção parece ter atraído mais público! Amanhã você já vai começar o treino com a live aberta!";
        yield return new WaitForSeconds(3);
        NumeroFase = 5;
        SceneManager.LoadScene ("Dia005");
    }

    //Fim de Fase 5
    public void FimDia005 (){
        if(MarcadorPontos.PontosFaseValor == 20)
        {
            MarcadorPontos.FaseConcluida = true;
            StartCoroutine (EsperaDia005 ());
        }
    }

    IEnumerator EsperaDia005()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Parabéns! Você foi convidado para o Show do Taustão! Se vira nos 40!";
        yield return new WaitForSeconds(3);
        NumeroFase = 6;
        SceneManager.LoadScene ("Dia006");
    }

    //Fim de Fase 6
    public void FimDia006 (){
        if(Dia006.TempoRestante <= 0)
        {
            if (MarcadorPontos.PontosFaseValor >= 20)
            {
                MarcadorPontos.FaseConcluida = true;
                StartCoroutine (EsperaDia006 ());
            } else {
                MarcadorPontos.FaseConcluida = true;
                StartCoroutine (EsperaDia006_2 ());
            }
        }
    }

    IEnumerator EsperaDia006_2()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Faltou habilidade em, só isso de pontos?";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene ("MenuGameOver");
    }

    IEnumerator EsperaDia006()
    {
        TextFinal.enabled = true;
        TextFinal.text = "Caramba! Deu pra cansar! Parabéns! Agora você tá famoso!";
        yield return new WaitForSeconds(3);
        NumeroFase = 7;
        SceneManager.LoadScene ("MenuGameOver");
    }
}
