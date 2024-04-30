using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuShop : MonoBehaviour
{
    public TextMeshProUGUI TextoBotaoComprarVida;
	public Button BotaoComprarVida;

    private int VidaMaximaComprada;
    private int NovaVidaMaxima;
    private int PrecoVidaMaxima;
    private int OperacaoCompra;
    private string UlitmoMenuVoltar;

    [SerializeField] private AudioSource SomCompra;

    void Start ()
    {
        UlitmoMenuVoltar = PlayerPrefs.GetString ("UltimoMenu");
        BotaoComprarVida.enabled = true;
        PrecoVidaMaxima = PlayerPrefs.GetInt("VidaMaxima") * 10;
    }

    public void ComprarVida ()
    {   
        if (PlayerPrefs.GetInt("VidaMaxima") < 8)
        {
            TextoBotaoComprarVida.text = "Vai custar " + PrecoVidaMaxima + " Fãs!";
		    BotaoComprarVida.onClick.AddListener(ConfirmaCompraVida);
        } else {
            TextoBotaoComprarVida.text = "Chega, já tem mais que um gato!";
        }
    }

    void ConfirmaCompraVida()
    {
        if (PlayerPrefs.GetInt("FasTotal") >= PrecoVidaMaxima)
        {
            VidaMaximaComprada = PlayerPrefs.GetInt("VidaMaxima");
            NovaVidaMaxima = VidaMaximaComprada + 1;
            PlayerPrefs.SetInt("VidaMaxima",  NovaVidaMaxima);
            OperacaoCompra = PlayerPrefs.GetInt("FasTotal") - PrecoVidaMaxima;
            PlayerPrefs.SetInt("FasTotal", OperacaoCompra);
            TextoBotaoComprarVida.text = "Sua vida máxima agora é: " + (PlayerPrefs.GetInt("VidaMaxima"));
            BotaoComprarVida.enabled = false;
            SomCompra.Play();
            StartCoroutine (RecarregaMenu());
        } else {
            TextoBotaoComprarVida.text = "Você não tem Fãs irmão";
            BotaoComprarVida.enabled = false;
            StartCoroutine (RecarregaMenu());
        }
	}

    public void VoltarMenu()
    {
        SceneManager.LoadScene(UlitmoMenuVoltar);
	}

    IEnumerator RecarregaMenu ()
    {
        yield return new WaitForSeconds (2);
        SceneManager.LoadScene ("MenuShop");
    }
}

