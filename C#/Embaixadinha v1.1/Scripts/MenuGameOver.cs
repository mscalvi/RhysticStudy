using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuGameOver : MonoBehaviour
{  
    private string UltimaFaseCod;
    private int CustoRecomeco;
    private int PontuacaoFinalValor;

    public TextMeshProUGUI PontuacaoFinalTexto;
    public TextMeshProUGUI PontosHighscoreMenu;

    public RectTransform PopUpPanel;
    public TextMeshProUGUI PopUpMensagem;
    public Animator PopUpAnimado;
    public TextMeshProUGUI TextoBotaoSubornarSim;
    public TextMeshProUGUI TextoBotaoSubornarNao;

    public TextMeshProUGUI TextoBotaoRecomecarCarreira;
	public Button BotaoRecomecarCarreira;
	public Button BotaoSubornarSim;

    private bool SemSom;
    public Sprite BotaoMutado;
    public Sprite BotaoSomLigado;
    public Button BotaoSom;

    // Start is called before the first frame update
    void Start()
    {
        SemSom = PlayerPrefs.GetInt("SomLigado") == 1;
        AudioListener.pause = SemSom;
        PopUpPanel.localScale = new Vector3 (0, 0, 0);
        CustoRecomeco = ControleFase.NumeroFase * 3;
        AtualizaPontuacao ();
        PlayerPrefs.SetString("UltimoMenu", "MenuGameOver");
    }

    void AtualizaPontuacao ()
    {
        PontuacaoFinalValor = MarcadorPontos.PontosTotalValor;
        UltimaFaseCod = PlayerPrefs.GetString("NumeroFase");
        PontuacaoFinalValor = PlayerPrefs.GetInt("PontuacaoFinal");
        MarcadorPontos.PontosTotalValor = PlayerPrefs.GetInt("HighScore");
        if (MarcadorPontos.PontosTotalValor == 1){
            PontosHighscoreMenu.text = $"Highscore: {MarcadorPontos.PontosTotalValor} Ponto!";
        } else {
            PontosHighscoreMenu.text = $"Highscore: {MarcadorPontos.PontosTotalValor} Pontos!";
        }
        if (PontuacaoFinalValor == 1){ 
            PontuacaoFinalTexto.text = $"Último: {PontuacaoFinalValor} Ponto!";
        } else {
            PontuacaoFinalTexto.text = $"Último: {PontuacaoFinalValor} Pontos!";
        }
    }

    public void RecomecarCarreira (string cena)
    {   
        TextoBotaoRecomecarCarreira.text = "Tem Certeza? Vai perder tudo!";
		BotaoRecomecarCarreira.onClick.AddListener(ConfirmaRecomecarCarreira);
    }

    void ConfirmaRecomecarCarreira()
    {
	    FimJogo.JaPerdeuVida = false;
        MarcadorPontos.PontosTotalValor = 0;
        SceneManager.LoadScene ("Dia001");
	}

    public void SubornarContinuar (string cena)
    {  
        PopUpPanel.localScale = new Vector3 (1, 1, 0);
        PopUpAnimado.Play("PopUpCampanhaInicial");
        BotaoSubornarSim.enabled = true;
        Debug.Log (ControleFase.NumeroFase);
        if (ControleFase.NumeroFase <= 5){
            PopUpMensagem.text = "Ah, você ainda nem é famoso o suficiente para alguém reparar, pode voltar!";
            TextoBotaoSubornarSim.text = "Vou supor que seja bom e aceitar.";
            TextoBotaoSubornarNao.text = "Vou pensar melhor.";
        } else {
            TextoBotaoSubornarSim.text = "Tá fácil, bora.";
            TextoBotaoSubornarNao.text = "Ai não dá né.";
            PopUpMensagem.text = "Isso vai te custar " + CustoRecomeco + " Fãs, além de " + (20-MarcadorPontos.PontosFaseValor) + " Pontos, tem certeza?";
        }
    }

    public void SubornarContinuarSim ()
    {  
        if (ControleFase.NumeroFase <= 5)
        {
            MarcadorPontos.PontosTotalValor = 0;
            FimJogo.JaPerdeuVida = false;
            SceneManager.LoadScene (ControleFase.UltimaFaseCod);
        } else {
        if (PlayerPrefs.GetInt("FasTotal") > CustoRecomeco){
            MarcadorPontos.PontosTotalValor = MarcadorPontos.PontosTotalValor - (20-MarcadorPontos.PontosFaseValor);
            MarcadorPontos.ViewersTotal -= CustoRecomeco;
            FimJogo.JaPerdeuVida = false;
            PlayerPrefs.SetInt("FasTotal", MarcadorPontos.ViewersTotal);
            SceneManager.LoadScene (ControleFase.UltimaFaseCod);
        } else {
            PopUpMensagem.text = "Você não tem todo esse poder, melhor começar do zero!";
            BotaoSubornarSim.enabled = false;
            TextoBotaoSubornarSim.text = "Não vai rolar.";
            TextoBotaoSubornarNao.text = "Aff.";
        }
        }
    }

    public void SubornarContinuarNao ()
    {  
        PopUpPanel.localScale = new Vector3 (0, 0, 0);
    }

    public void MercadoItens (string cena)
    {  
        SceneManager.LoadScene ("MenuShop");
    }

    public void VoltarComeco (string cena)
    {   
        SceneManager.LoadScene ("MenuInicial");
    }

    public void Configuracoes (string cena)
    {  
        SemSom = !SemSom;
        AudioListener.pause = SemSom;
        PlayerPrefs.SetInt("SomLigado", SemSom ? 1 : 0);
        if (SemSom == true){
            BotaoSom.image.sprite = BotaoMutado;
        } else {
            BotaoSom.image.sprite = BotaoSomLigado;
        }
    }

    public void Sair ()
    {
        Debug.Log ("Sairia, mas...");
        Application.Quit ();
    }
}
