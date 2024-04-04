using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatsPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Player1;
    [SerializeField] private TextMeshProUGUI Player2;
    [SerializeField] private TextMeshProUGUI Player3;
    [SerializeField] private TextMeshProUGUI Player4;

    [SerializeField] private TextMeshProUGUI CDamage1;
    [SerializeField] private TextMeshProUGUI CDamage2;
    [SerializeField] private TextMeshProUGUI CDamage3;
    [SerializeField] private TextMeshProUGUI CDamage4;

    void Start ()
    {
        Player1.text = "New Player 1";
        Player2.text = "New Player 2";
        Player3.text = "New Player 3";
        Player4.text = "New Player 4";

        CDamage1.text = "0";
        CDamage2.text = "0";
        CDamage3.text = "0";
        CDamage4.text = "0";

    }

    void OnEnable()
    {
        switch (GameController.ActivePlayer)
        {
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}
