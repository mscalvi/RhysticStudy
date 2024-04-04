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

    private int TotalLifeP1, TotalLifeP2, TotalLifeP3, TotalLifeP4;
    public static int ActivePlayer;

    private GameObject StatsPanel;

    [SerializeField] private Image BlankStat;
    [SerializeField] private Sprite CmdDmg;

    // Start is called before the first frame update
    void Start()
    {
        StatsPanel = GameObject.FindWithTag("StatsPanel");
        StatsPanel.SetActive(false);

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
        StatsPanel.SetActive(false);
    }
}
