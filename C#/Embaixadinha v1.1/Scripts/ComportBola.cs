using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ComportBola : MonoBehaviour
{
    [SerializeField] private Transform StartPos;

    [SerializeField] private Image SetaDirecao;

    private Rigidbody2D Bola;
    private float Force = 0;
    private float ForcaBotaoBola;
    private float ForcaBotaoBolaFinal;

    public static bool FimJogo;
    public static bool LiberaJogo;
    public static bool mousePresent;
    public static bool Restart;
    public static bool ContinuarPause;

    public TextMeshProUGUI TextVidas;
    [SerializeField] private TextMeshPro Movimento;

    AudioSource SomChute;

    // Start is called before the first frame update
    void Start()
    {
        SomChute = GetComponent<AudioSource>();
        PosicaoBola ();
        Bola = GetComponent<Rigidbody2D> ();
        FimJogo = false;
        Force = 0;
        MarcadorPontos.PrimeiroChute = true;
        TextVidas.enabled = false;
        Movimento.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (SystemInfo.deviceType == DeviceType.Desktop){
            ChuteBolaMouse ();
        } 
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            ChuteBolaTouch ();
        }
    }

    // Posicao Inicial da Bola
    void PosicaoBola ()
    {
        this.gameObject.transform.position = StartPos.position;
    }

    // Chute na Bola
    void ChuteBolaTouch ()
    {
        var touch = Input.GetTouch(0);

        if (AreaMouse.LiberaRotacao == true && FimJogo == false && MarcadorPontos.ComecaFase == true && MarcadorPontos.FaseConcluida == false)
        {
            Vector3 PosicaoBola = gameObject.GetComponent<Rigidbody2D>().transform.position;
            if (PosicaoBola.y < -0.8f)
            {
                Vector3 FingerPosition = Input.GetTouch(0).position;
                FingerPosition = Camera.main.ScreenToWorldPoint (FingerPosition);
                Vector2 DirectionSeta = new Vector2 (FingerPosition.x - SetaDirecao.transform.position.x, FingerPosition.y - SetaDirecao.transform.position.y);
                SetaDirecao.transform.up = DirectionSeta;
                if(touch.phase == TouchPhase.Began)
                {
                    ForcaBotaoBola = Time.time;
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    if (MarcadorPontos.PrimeiroChute == true)
                    {
                        Bola.AddForce (-DirectionSeta * 200);
                        SomChute.Play();
                        MarcadorPontos.PrimeiroChute = false;
                        Movimento.enabled = true;
                        Movimento.text = "Chutou!";
                        StartCoroutine (TempoMovimento());
                    } else {
                        ForcaBotaoBolaFinal = Time.time - ForcaBotaoBola;
                        Force = ForcaBotaoBolaFinal * 500;
                        if (Force > 400)
                        {
                            Force = 400;
                        }
                        if (Force < 200)
                        {
                            Force = 200;
                        }
                        Bola.velocity = Vector3.zero;
                        Bola.AddForce (-DirectionSeta * -100);
                        Bola.AddForce (-DirectionSeta * Force);
                        SomChute.Play();
                        Movimento.enabled = true;
                        Movimento.text = "Chutou!";
                        StartCoroutine (TempoMovimento());
                    }
                }
            } else {
                if (PosicaoBola.y < 1.8f)
                {
                    Vector3 MousePosition = Input.mousePosition;
                    MousePosition = Camera.main.ScreenToWorldPoint (MousePosition);
                    Vector2 DirectionSeta = new Vector2 (MousePosition.x - SetaDirecao.transform.position.x, MousePosition.y - SetaDirecao.transform.position.y);
                    SetaDirecao.transform.up = DirectionSeta;
                    if(touch.phase == TouchPhase.Ended)
                    {
                        Bola.AddForce (-DirectionSeta * 50);
                        SomChute.Play();
                        Movimento.enabled = true;
                        Movimento.text = "Cabeceou!";
                        StartCoroutine (TempoMovimento());
                    }
                } else {
                    if(touch.phase == TouchPhase.Ended)
                    {
                        Movimento.enabled = true;
                        Movimento.text = "Alto Demais!";
                        StartCoroutine (TempoMovimento());
                    }
                }
            }
        }
    }

    void ChuteBolaMouse ()
    {
        if (AreaMouse.LiberaRotacao == true && FimJogo == false && MarcadorPontos.ComecaFase == true && MarcadorPontos.FaseConcluida == false)
        {
            Vector3 PosicaoBola = gameObject.GetComponent<Rigidbody2D>().transform.position;
            if (PosicaoBola.y < -0.8f)
            {
                Vector3 MousePosition = Input.mousePosition;
                MousePosition = Camera.main.ScreenToWorldPoint (MousePosition);
                Vector2 DirectionSeta = new Vector2 (MousePosition.x - SetaDirecao.transform.position.x, MousePosition.y - SetaDirecao.transform.position.y);
                SetaDirecao.transform.up = DirectionSeta;
                if(Input.GetButtonDown("Fire1"))
                {
                    ForcaBotaoBola = Time.time;
                }
                if(Input.GetButtonUp("Fire1"))
                {
                    if (MarcadorPontos.PrimeiroChute == true)
                    {
                        Bola.AddForce (-DirectionSeta * 200);
                        SomChute.Play();
                        MarcadorPontos.PrimeiroChute = false;
                        Movimento.enabled = true;
                        Movimento.text = "Chutou!";
                        StartCoroutine (TempoMovimento());
                    } else {
                        ForcaBotaoBolaFinal = Time.time - ForcaBotaoBola;
                        Force = ForcaBotaoBolaFinal * 500;
                        if (Force > 400)
                        {
                            Force = 400;
                        }
                        if (Force < 200)
                        {
                            Force = 200;
                        }
                        Bola.velocity = Vector3.zero;
                        Bola.AddForce (-DirectionSeta * -100);
                        Bola.AddForce (-DirectionSeta * Force);
                        SomChute.Play();
                        Movimento.enabled = true;
                        Movimento.text = "Chutou!";
                        StartCoroutine (TempoMovimento());
                    } 
                }
            } else {
                if (PosicaoBola.y < 1.8f)
                {
                    Vector3 MousePosition = Input.mousePosition;
                    MousePosition = Camera.main.ScreenToWorldPoint (MousePosition);
                    Vector2 DirectionSeta = new Vector2 (MousePosition.x - SetaDirecao.transform.position.x, MousePosition.y - SetaDirecao.transform.position.y);
                    SetaDirecao.transform.up = DirectionSeta;
                    if(Input.GetButtonUp("Fire1"))
                    {
                        Bola.AddForce (-DirectionSeta * 50);
                        SomChute.Play();
                        Movimento.enabled = true;
                        Movimento.text = "Cabeceou!";
                        StartCoroutine (TempoMovimento());
                    }
                }
                else {if(Input.GetButtonUp("Fire1"))
                    {
                        Movimento.enabled = true;
                        Movimento.text = "Alto Demais!";
                        StartCoroutine (TempoMovimento());
                    }
                }
            }
        }
    }

    IEnumerator TempoMovimento ()
    {
        yield return new WaitForSeconds (0.5f);
        Movimento.enabled = false;
    }

    //Fim de Jogo
    public void TerminarJogo()
    {
        TextVidas.enabled = true;
        TextVidas.text = "Muito eita";
        FimJogo = true;
        PlayerPrefs.SetInt("ContinuarPause", 0);
        StartCoroutine (EsperarTempo ());
    }
    
    IEnumerator EsperarTempo()
    {
        yield return new WaitForSecondsRealtime(1);
        TextVidas.enabled = false;
        SceneManager.LoadScene ("MenuGameOver");
    }

    //Perda de Vida
    public void RePosicaoBola ()
    {
        TextVidas.enabled = true;
        TextVidas.text = "Eita";
        StartCoroutine (EsperarTempoRestart());
    }
    
    IEnumerator EsperarTempoRestart()
    {
        yield return new WaitForSecondsRealtime(1);
        this.gameObject.transform.position = StartPos.position;
        MarcadorPontos.PrimeiroChute = true;
        Bola.velocity = Vector3.zero;
        Vector2 SetaRestart = new Vector2 (1, 1);
        Bola.AddForce (SetaRestart * 0);
        TextVidas.enabled = false;
        MarcadorPontos.ComecaFase = true;
    }

    public void NovoViewer()
    {
        MarcadorPontos.ViewersTotal += 1;
        PlayerPrefs.SetInt("FasTotal", MarcadorPontos.ViewersTotal);
    }
}
