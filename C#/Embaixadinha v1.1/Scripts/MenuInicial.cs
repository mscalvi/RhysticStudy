using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInicial : MonoBehaviour
{
    public TextMeshProUGUI PontosHighscoreMenu;

    public TextMeshProUGUI TextoBotaoContinuar;

    public RectTransform PopUpPanel;
    public TextMeshProUGUI PopUpMensagem;
    public Animator PopUpAnimado;

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
        PlayerPrefs.SetString("UltimoMenu", "MenuInicial");
        //PlayerPrefs.SetInt("VidaMaxima", 3); //Em caso de reinício, tire o comentário
        Debug.Log (PlayerPrefs.GetInt("VidaMaxima"));
        if (!PlayerPrefs.HasKey("VidaMaxima"))
        {
            PlayerPrefs.SetInt("VidaMaxima", 3);
            Debug.Log (PlayerPrefs.GetInt("VidaMaxima"));
        }
        ChecaHighscore ();
    }

    //Começar Campanha
    public void ModoCampanha ()
    {  
        PopUpPanel.localScale = new Vector3 (1, 1, 0);
        PopUpAnimado.Play("PopUpCampanhaInicial");
        PopUpMensagem.text = "Tem certeza? Vai apagar o progresso salvo!";
    }

    public void ModoCampanhaSim ()
    {  
        MarcadorPontos.PontosTotalValor = 0;
        FimJogo.JaPerdeuVida = false;
        SceneManager.LoadScene ("Dia001");
    }

    public void ModoCampanhaNao ()
    { 
        PopUpPanel.localScale = new Vector3 (0, 0, 0);
    }

    public void ContinuarCampanha (string cena)
    {
        if (PlayerPrefs.GetInt("ContinuarPause") == 1){
            MarcadorPontos.VidasRestantes = PlayerPrefs.GetInt("VidasRestantes");
            MarcadorPontos.PontosTotalValor = PlayerPrefs.GetInt("PontosComecoFase");
            SceneManager.LoadScene (PlayerPrefs.GetString("UltimaFaseIniciada"));
        } else {
            TextoBotaoContinuar.text = "Você não tem nada salvo!";
        }
    }

    public void EscolhadeNivel (string cena)
    {   
        Debug.Log ("Em Construção");
        //Fases Infinitas
        //SceneManager.LoadScene ("002Fases");
    }

    public void MercadoItens (string cena)
    {  
        SceneManager.LoadScene ("MenuShop");
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
        Application.Quit ();
    }
    
    void ChecaHighscore()
    {
        if (PlayerPrefs.GetInt("HighScore", 0) != 0){
            MarcadorPontos.PontosTotalValor = PlayerPrefs.GetInt("HighScore", 0);
        } else {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        if (MarcadorPontos.PontosTotalValor == 1){
            PontosHighscoreMenu.text = $"Highscore: {MarcadorPontos.PontosTotalValor} Ponto!";
        } else {
            PontosHighscoreMenu.text = $"Highscore: {MarcadorPontos.PontosTotalValor} Pontos!";
        }
    }
}
