using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MarcadorPontos : MonoBehaviour
{
    //Pontuacao
    public static int PontosTotalValor;
    public static int PontosFaseValor;
    public static int PontuacaoFinal;
    public static int ViewersTotal;
    public static int VidasRestantes;
    public static int VidasMaximas;

    public static bool ComecaFase;
    public static bool PrimeiroChute;
    public static bool FaseConcluida;
    private bool TextoPulado;

    public TextMeshProUGUI PontosTexto;
    public TextMeshProUGUI PontosHighscore;
    public TextMeshProUGUI TextIntroducao;
    public TextMeshProUGUI TextTutorial;
    public TextMeshProUGUI TextInicio;
    public TextMeshProUGUI TextFas;
    Coroutine TextosIntrodutorios;
    private float VelocidadeTexto = 0.02f;

    [SerializeField] Image Vidas1;
    [SerializeField] Image Vidas2;
    [SerializeField] Image Vidas3;
    [SerializeField] Image Vidas4;
    [SerializeField] Image Vidas5;
    [SerializeField] Image Vidas6;
    [SerializeField] Image Vidas7;
    [SerializeField] Image Vidas8;

    // Start is called before the first frame update
    void Start()
    {
        FaseConcluida = false;
        ComecaFase = false;
        TextIntroducao.enabled = false;
        TextTutorial.enabled = false;
        TextInicio.enabled = false;
        TextoPulado = false;
        //PlayerPrefs.SetInt("VidasRestantes", 3); //Em caso de reinício, tire o comentário
        VidasMaximas = PlayerPrefs.GetInt("VidaMaxima");
        if (FimJogo.JaPerdeuVida == false)
        {
            PlayerPrefs.SetInt("VidasRestantes", VidasMaximas);
        }
        VidasRestantes = PlayerPrefs.GetInt("VidasRestantes", PlayerPrefs.GetInt("VidaMaxima"));
        ContadordeVidas ();
        IntroducaoFase ();
    }

    // Update is called once per frame
    void Update()
    {
        SetaHighscore ();
	    ContadordePontos ();
        SetaViewers ();
        if (PontosTotalValor == 1){
            PontosTexto.text = $"{PontosTotalValor} Ponto!";
        } else {
            PontosTexto.text = $"{PontosTotalValor} Pontos!";
        }
		if (Input.GetMouseButtonDown(0) && TextoPulado == false) {
            StopCoroutine(TextosIntrodutorios);
            TextIntroducao.enabled = false;
            TextTutorial.enabled = false;
            StartCoroutine (DelayComeco());
        }
        if (FimJogo.PerdeuVida == true){
            ContadordeVidas ();
        }
    }

    //Contar Pontos
    void ContadordePontos ()
    {
        if (AreaMouse.LiberaRotacao == true && ComportBola.FimJogo == false && ComecaFase == true && MarcadorPontos.FaseConcluida == false)
        {
            if(Input.GetButtonUp("Fire1"))
            {
                FaseConcluida = false;
                if (PontosTotalValor == 1){
                    PontosTexto.text = $"{PontosTotalValor} Ponto!";
                } else {
                    PontosTexto.text = $"{PontosTotalValor} Pontos!";
                }
                PontosTotalValor += 1;
                PontosFaseValor += 1;
                PlayerPrefs.SetInt("PontuacaoFinal", PontosTotalValor);
            }
        }
    }

    //Highscore
    public void SetaViewers()
    {
        TextFas.text = $"Fãs: {PlayerPrefs.GetInt("FasTotal", 0)}!";
    }

    //Fãs
    public void SetaHighscore()
    {
        PontosHighscore.text = $"Highscore: {PlayerPrefs.GetInt("HighScore")}!";
        if (PontosTotalValor > PlayerPrefs.GetInt("HighScore", PontosTotalValor))
        {
            PlayerPrefs.SetInt("HighScore", PontosTotalValor);
        }
    }

    //Introdução da Fase
    public void IntroducaoFase ()
    {
        TextosIntrodutorios = StartCoroutine(LetraLetraIntroducao());
    }

    IEnumerator LetraLetraIntroducao()
    {
        int CaracteresTotaisInro = TextIntroducao.text.Length;
        TextIntroducao.maxVisibleCharacters = 0;
        TextIntroducao.enabled = true;
        for(int i = 0; i <= CaracteresTotaisInro; i++)
        {
            TextIntroducao.maxVisibleCharacters = i;
            yield return new WaitForSeconds(VelocidadeTexto);
        }
        yield return new WaitForSeconds(2);
        TextIntroducao.enabled = false;
        TextTutorial.maxVisibleCharacters = 0;
        TextTutorial.enabled = true;
        int CaracteresTotaisTut = TextTutorial.text.Length;
        for(int j = 0; j <= CaracteresTotaisTut; j++)
        {
            TextTutorial.maxVisibleCharacters = j;
            yield return new WaitForSeconds(VelocidadeTexto);
        }
        yield return new WaitForSeconds(2);
        TextTutorial.enabled = false;
        TextInicio.enabled = true;
        yield return new WaitForSeconds(2);
        TextInicio.enabled = false;
        ComecaFase = true;
    }

    IEnumerator DelayComeco()
    {
        TextInicio.enabled = true;
        TextInicio.text = "Valendo!";
        yield return new WaitForSeconds(1);
        TextInicio.enabled = false;
        TextoPulado = true;
        ComecaFase = true;
    }

    //Contador de Vidas
    public void ContadordeVidas ()
    {  
        FimJogo.PerdeuVida = false;
        switch (VidasRestantes)
        {
            case 0:
                Vidas1.enabled = false;
                Vidas2.enabled = false;
                Vidas3.enabled = false;
                Vidas4.enabled = false;
                Vidas5.enabled = false;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 1:
                Vidas1.enabled = true;
                Vidas2.enabled = false;
                Vidas3.enabled = false;
                Vidas4.enabled = false;
                Vidas5.enabled = false;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 2:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = false;
                Vidas4.enabled = false;
                Vidas5.enabled = false;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 3:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = false;
                Vidas5.enabled = false;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 4:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = true;
                Vidas5.enabled = false;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 5:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = true;
                Vidas5.enabled = true;
                Vidas6.enabled = false;
                Vidas7.enabled = false;
                Vidas8.enabled = false;
                break;
            case 6:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = true;
                Vidas5.enabled = true;
                Vidas6.enabled = true;
                Vidas7.enabled = true;
                Vidas8.enabled = false;
                break;
            case 7:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = true;
                Vidas5.enabled = true;
                Vidas6.enabled = true;
                Vidas7.enabled = true;
                Vidas8.enabled = false;
                break;
            case 8:
                Vidas1.enabled = true;
                Vidas2.enabled = true;
                Vidas3.enabled = true;
                Vidas4.enabled = true;
                Vidas5.enabled = true;
                Vidas6.enabled = true;
                Vidas7.enabled = true;
                Vidas8.enabled = true;
                break;
            default:
                break;
        }
    }
}
