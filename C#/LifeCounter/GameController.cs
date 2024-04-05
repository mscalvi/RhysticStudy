using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Player1;
    [SerializeField] private TextMeshProUGUI Player2;
    [SerializeField] private TextMeshProUGUI Player3;
    [SerializeField] private TextMeshProUGUI Player4;

    [SerializeField] private TextMeshProUGUI LifeP1;
    [SerializeField] private TextMeshProUGUI LifeP2;
    [SerializeField] private TextMeshProUGUI LifeP3;
    [SerializeField] private TextMeshProUGUI LifeP4;

    private bool Deck1, Deck2, Deck3, Deck4;

    private int TotalLifeP1, TotalLifeP2, TotalLifeP3, TotalLifeP4;
    public static int ActivePlayer;

    private GameObject StatsPanel;
    private GameObject ProtectionPanel1;
    private GameObject ProtectionPanel2;

    [SerializeField] private GameObject StatsInfo11;
    [SerializeField] private GameObject StatsInfo21;
    [SerializeField] private GameObject StatsInfo31;
    [SerializeField] private GameObject StatsInfo41;
    [SerializeField] private GameObject StatsInfo51;
    [SerializeField] private GameObject StatsInfo61;
    [SerializeField] private GameObject StatsInfo71;
    [SerializeField] private GameObject StatsInfo12;
    [SerializeField] private GameObject StatsInfo22;
    [SerializeField] private GameObject StatsInfo32;
    [SerializeField] private GameObject StatsInfo42;
    [SerializeField] private GameObject StatsInfo52;
    [SerializeField] private GameObject StatsInfo62;
    [SerializeField] private GameObject StatsInfo72;
    [SerializeField] private GameObject StatsInfo13;
    [SerializeField] private GameObject StatsInfo23;
    [SerializeField] private GameObject StatsInfo33;
    [SerializeField] private GameObject StatsInfo43;
    [SerializeField] private GameObject StatsInfo53;
    [SerializeField] private GameObject StatsInfo63;
    [SerializeField] private GameObject StatsInfo73;
    [SerializeField] private GameObject StatsInfo14;
    [SerializeField] private GameObject StatsInfo24;
    [SerializeField] private GameObject StatsInfo34;
    [SerializeField] private GameObject StatsInfo44;
    [SerializeField] private GameObject StatsInfo54;
    [SerializeField] private GameObject StatsInfo64;
    [SerializeField] private GameObject StatsInfo74;

    [SerializeField] private TextMeshProUGUI StatsInfo11T;
    [SerializeField] private TextMeshProUGUI StatsInfo21T;
    [SerializeField] private TextMeshProUGUI StatsInfo31T;
    [SerializeField] private TextMeshProUGUI StatsInfo41T;
    [SerializeField] private TextMeshProUGUI StatsInfo51T;
    [SerializeField] private TextMeshProUGUI StatsInfo61T;
    [SerializeField] private TextMeshProUGUI StatsInfo71T;
    [SerializeField] private TextMeshProUGUI StatsInfo12T;
    [SerializeField] private TextMeshProUGUI StatsInfo22T;
    [SerializeField] private TextMeshProUGUI StatsInfo32T;
    [SerializeField] private TextMeshProUGUI StatsInfo42T;
    [SerializeField] private TextMeshProUGUI StatsInfo52T;
    [SerializeField] private TextMeshProUGUI StatsInfo62T;
    [SerializeField] private TextMeshProUGUI StatsInfo72T;
    [SerializeField] private TextMeshProUGUI StatsInfo13T;
    [SerializeField] private TextMeshProUGUI StatsInfo23T;
    [SerializeField] private TextMeshProUGUI StatsInfo33T;
    [SerializeField] private TextMeshProUGUI StatsInfo43T;
    [SerializeField] private TextMeshProUGUI StatsInfo53T;
    [SerializeField] private TextMeshProUGUI StatsInfo63T;
    [SerializeField] private TextMeshProUGUI StatsInfo73T;
    [SerializeField] private TextMeshProUGUI StatsInfo14T;
    [SerializeField] private TextMeshProUGUI StatsInfo24T;
    [SerializeField] private TextMeshProUGUI StatsInfo34T;
    [SerializeField] private TextMeshProUGUI StatsInfo44T;
    [SerializeField] private TextMeshProUGUI StatsInfo54T;
    [SerializeField] private TextMeshProUGUI StatsInfo64T;
    [SerializeField] private TextMeshProUGUI StatsInfo74T;


    // Start is called before the first frame update
    void Start()
    {
        StatsPanel = GameObject.FindWithTag("StatsPanel");
        StatsPanel.SetActive(false);
        ProtectionPanel1 = GameObject.FindWithTag("ProtectionPanel1");
        ProtectionPanel2 = GameObject.FindWithTag("ProtectionPanel2");
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 7; j++)
            {
                string StatsInfoName = "StatsInfo" + j.ToString() + i.ToString();
                GameObject StatsInfo = GameObject.Find(StatsInfoName);
                if (StatsInfo != null)
                {
                    Debug.Log(StatsInfo);
                    StatsInfo.SetActive(false);
                }
            }
        }

        Player1.text = "New Player 1";
        Player2.text = "New Player 2";
        Player3.text = "New Player 3";
        Player4.text = "New Player 4";

        TotalLifeP1 = 40; 
        TotalLifeP2 = 40; 
        TotalLifeP3 = 40;
        TotalLifeP4 = 40;

        LifeP1.text = TotalLifeP1.ToString();
        LifeP2.text = TotalLifeP2.ToString();
        LifeP3.text = TotalLifeP3.ToString();
        LifeP4.text = TotalLifeP4.ToString();

        PlayerPrefs.SetInt("CmdDmgP11", 0);
        PlayerPrefs.SetInt("CmdDmgP21", 0);
        PlayerPrefs.SetInt("CmdDmgP31", 0);
        PlayerPrefs.SetInt("CmdDmgP41", 0);
        PlayerPrefs.SetInt("CmdDmgP12", 0);
        PlayerPrefs.SetInt("CmdDmgP22", 0);
        PlayerPrefs.SetInt("CmdDmgP32", 0);
        PlayerPrefs.SetInt("CmdDmgP42", 0);
        PlayerPrefs.SetInt("CmdDmgP13", 0);
        PlayerPrefs.SetInt("CmdDmgP23", 0);
        PlayerPrefs.SetInt("CmdDmgP33", 0);
        PlayerPrefs.SetInt("CmdDmgP43", 0);
        PlayerPrefs.SetInt("CmdDmgP14", 0);
        PlayerPrefs.SetInt("CmdDmgP24", 0);
        PlayerPrefs.SetInt("CmdDmgP34", 0);
        PlayerPrefs.SetInt("CmdDmgP44", 0);
        PlayerPrefs.SetInt("Tax1", 0);
        PlayerPrefs.SetInt("Tax2", 0);
        PlayerPrefs.SetInt("Tax3", 0);
        PlayerPrefs.SetInt("Tax4", 0);
        PlayerPrefs.SetInt("Poison1", 0);
        PlayerPrefs.SetInt("Poison2", 0);
        PlayerPrefs.SetInt("Poison3", 0);
        PlayerPrefs.SetInt("Poison4", 0);
        PlayerPrefs.SetInt("Exp1", 0);
        PlayerPrefs.SetInt("Exp2", 0);
        PlayerPrefs.SetInt("Exp3", 0);
        PlayerPrefs.SetInt("Exp4", 0);
    }

    public void Life1Up ()
    {
        TotalLifeP1++;
        LifeP1.text = TotalLifeP1.ToString();
    }
    public void Life1Down()
    {
        TotalLifeP1--;
        LifeP1.text = TotalLifeP1.ToString();
    }
    public void Life2Up()
    {
        TotalLifeP2++;
        LifeP2.text = TotalLifeP2.ToString();
    }
    public void Life2Down()
    {
        TotalLifeP2--;
        LifeP2.text = TotalLifeP2.ToString();
    }
    public void Life3Up()
    {
        TotalLifeP3++;
        LifeP3.text = TotalLifeP3.ToString();
    }
    public void Life3Down()
    {
        TotalLifeP3--;
        LifeP3.text = TotalLifeP3.ToString();
    }
    public void Life4Up()
    {
        TotalLifeP4++;
        LifeP4.text = TotalLifeP4.ToString();
    }
    public void Life4Down()
    {
        TotalLifeP4--;
        LifeP4.text = TotalLifeP4.ToString();
    }

    public void StatsPlayer1 ()
    {
        ActivePlayer = 1;
        StatsPanel.SetActive(true);
    }
    public void StatsPlayer2()
    {
        ActivePlayer = 2;
        StatsPanel.SetActive(true);
    }
    public void StatsPlayer3()
    {
        ActivePlayer = 3;
        StatsPanel.SetActive(true);
    }
    public void StatsPlayer4()
    {
        ActivePlayer = 4;
        StatsPanel.SetActive(true);
    }

    public void StatsConfirm ()
    {
        switch (ActivePlayer)
        {
            case 1:
                Att1 ();
                break;
            case 2:
                Att2();
                break;
            case 3:
                Att3();
                break;
            case 4:
                Att4();
                break;
            default:
                break;
        }
        StatsPanel.SetActive(false);
    }

    void Att1()
    {
        if (PlayerPrefs.GetInt("CmdDmgP11") != 0)
        {
            StatsInfo11.SetActive(true);
            StatsInfo11T.text = PlayerPrefs.GetString("Player1", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP11").ToString();
        }
        else
        {
            StatsInfo11.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP21") != 0)
        {
            StatsInfo21.SetActive(true);
            StatsInfo21T.text = PlayerPrefs.GetString("Player2", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP21").ToString();
        }
        else
        {
            StatsInfo21.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP31") != 0)
        {
            StatsInfo31.SetActive(true);
            StatsInfo31T.text = PlayerPrefs.GetString("Player3", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP31").ToString();
        }
        else
        {
            StatsInfo31.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP41") != 0)
        {
            StatsInfo41.SetActive(true);
            StatsInfo41T.text = PlayerPrefs.GetString("Player4", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP41").ToString();
        }
        else
        {
            StatsInfo41.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Poison1") != 0)
        {
            StatsInfo51.SetActive(true);
            StatsInfo51T.text = "Poison\n" + PlayerPrefs.GetInt("Poison1").ToString();
        }
        else
        {
            StatsInfo51.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Exp1") != 0)
        {
            StatsInfo61.SetActive(true);
            StatsInfo61T.text = "Experience\n" + PlayerPrefs.GetInt("Exp1").ToString();
        }
        else
        {
            StatsInfo61.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tax1") != 0)
        {
            StatsInfo71.SetActive(true);
            StatsInfo71T.text = "Tax\n" + PlayerPrefs.GetInt("Tax1").ToString();
        }
        else
        {
            StatsInfo71.SetActive(false);
        }
    }

    void Att2()
    {
        if (PlayerPrefs.GetInt("CmdDmgP12") != 0)
        {
            StatsInfo12.SetActive(true);
            StatsInfo12T.text = PlayerPrefs.GetString("Player2", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP12").ToString();
        }
        else
        {
            StatsInfo11.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP22") != 0)
        {
            StatsInfo22.SetActive(true);
            StatsInfo22T.text = PlayerPrefs.GetString("Player2", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP22").ToString();
        }
        else
        {
            StatsInfo21.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP32") != 0)
        {
            StatsInfo32.SetActive(true);
            StatsInfo32T.text = PlayerPrefs.GetString("Player3", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP32").ToString();
        }
        else
        {
            StatsInfo32.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP42") != 0)
        {
            StatsInfo42.SetActive(true);
            StatsInfo42T.text = PlayerPrefs.GetString("Player4", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP42").ToString();
        }
        else
        {
            StatsInfo41.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Poison2") != 0)
        {
            StatsInfo52.SetActive(true);
            StatsInfo52T.text = "Poison\n" + PlayerPrefs.GetInt("Poison2").ToString();
        }
        else
        {
            StatsInfo51.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Exp2") != 0)
        {
            StatsInfo62.SetActive(true);
            StatsInfo62T.text = "Experience\n" + PlayerPrefs.GetInt("Exp2").ToString();
        }
        else
        {
            StatsInfo62.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tax2") != 0)
        {
            StatsInfo72.SetActive(true);
            StatsInfo72T.text = "Tax\n" + PlayerPrefs.GetInt("Tax2").ToString();
        }
        else
        {
            StatsInfo72.SetActive(false);
        }
    }

    void Att3()
    {
        if (PlayerPrefs.GetInt("CmdDmgP13") != 0)
        {
            StatsInfo13.SetActive(true);
            StatsInfo13T.text = PlayerPrefs.GetString("Player1", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP13").ToString();
        }
        else
        {
            StatsInfo13.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP23") != 0)
        {
            StatsInfo23.SetActive(true);
            StatsInfo23T.text = PlayerPrefs.GetString("Player2", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP23").ToString();
        }
        else
        {
            StatsInfo23.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP33") != 0)
        {
            StatsInfo33.SetActive(true);
            StatsInfo33T.text = PlayerPrefs.GetString("Player3", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP33").ToString();
        }
        else
        {
            StatsInfo33.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP43") != 0)
        {
            StatsInfo43.SetActive(true);
            StatsInfo43T.text = PlayerPrefs.GetString("Player4", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP43").ToString();
        }
        else
        {
            StatsInfo43.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Poison3") != 0)
        {
            StatsInfo53.SetActive(true);
            StatsInfo53T.text = "Poison\n" + PlayerPrefs.GetInt("Poison3").ToString();
        }
        else
        {
            StatsInfo53.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Exp3") != 0)
        {
            StatsInfo63.SetActive(true);
            StatsInfo63T.text = "Experience\n" + PlayerPrefs.GetInt("Exp3").ToString();
        }
        else
        {
            StatsInfo61.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tax3") != 0)
        {
            StatsInfo73.SetActive(true);
            StatsInfo73T.text = "Tax\n" + PlayerPrefs.GetInt("Tax3").ToString();
        }
        else
        {
            StatsInfo71.SetActive(false);
        }
    }

    void Att4()
    {
        if (PlayerPrefs.GetInt("CmdDmgP14") != 0)
        {
            StatsInfo14.SetActive(true);
            StatsInfo14T.text = PlayerPrefs.GetString("Player1", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP14").ToString();
        }
        else
        {
            StatsInfo14.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP24") != 0)
        {
            StatsInfo24.SetActive(true);
            StatsInfo24T.text = PlayerPrefs.GetString("Player2", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP24").ToString();
        }
        else
        {
            StatsInfo24.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP34") != 0)
        {
            StatsInfo34.SetActive(true);
            StatsInfo34T.text = PlayerPrefs.GetString("Player3", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP34").ToString();
        }
        else
        {
            StatsInfo34.SetActive(false);
        }

        if (PlayerPrefs.GetInt("CmdDmgP44") != 0)
        {
            StatsInfo44.SetActive(true);
            StatsInfo44T.text = PlayerPrefs.GetString("Player4", "New Player") + "\n" + PlayerPrefs.GetInt("CmdDmgP44").ToString();
        }
        else
        {
            StatsInfo44.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Poison4") != 0)
        {
            StatsInfo54.SetActive(true);
            StatsInfo54T.text = "Poison\n" + PlayerPrefs.GetInt("Poison4").ToString();
        }
        else
        {
            StatsInfo51.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Exp4") != 0)
        {
            StatsInfo64.SetActive(true);
            StatsInfo64T.text = "Experience\n" + PlayerPrefs.GetInt("Exp4").ToString();
        }
        else
        {
            StatsInfo61.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Tax4") != 0)
        {
            StatsInfo74.SetActive(true);
            StatsInfo74T.text = "Tax\n" + PlayerPrefs.GetInt("Tax4").ToString();
        }
        else
        {
            StatsInfo74.SetActive(false);
        }
    }

    public void StartGame ()
    {
        if (Deck1 && Deck2 && Deck3 && Deck4)
        {
            Debug.Log("Pronto");
            ProtectionPanel1.SetActive(false);
            ProtectionPanel2.SetActive(false);
            //função para criar jogo na planilha
        }
    }

    public void AddPlayer1 ()
    {
        Deck1 = true;
        Debug.Log("Deck 1 Ok");
    }

    public void AddPlayer2()
    {
        Deck2 = true;
        Debug.Log("Deck 2 Ok");
    }

    public void AddPlayer3()
    {
        Deck3 = true;
        Debug.Log("Deck 3 Ok");
    }

    public void AddPlayer4()
    {
        Deck4 = true;
        Debug.Log("Deck 4 Ok");
    }
}
