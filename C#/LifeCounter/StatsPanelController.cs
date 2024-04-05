using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

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

    [SerializeField] private TextMeshProUGUI PCounter;
    [SerializeField] private TextMeshProUGUI ExpCounter;
    [SerializeField] private TextMeshProUGUI ComTaxCounter;


void Start ()
    {
        Player1.text = PlayerPrefs.GetString("Player1", "New Player");
        Player2.text = PlayerPrefs.GetString("Player2", "New Player");
        Player3.text = PlayerPrefs.GetString("Player3", "New Player");
        Player4.text = PlayerPrefs.GetString("Player4", "New Player");

        CDamage1.text = "0";
        CDamage2.text = "0";
        CDamage3.text = "0";
        CDamage4.text = "0";

        PCounter.text = "0";
        ExpCounter.text = "0";
        ComTaxCounter.text = "0";

    }

    void OnEnable()
    {
        switch (GameController.ActivePlayer)
        {
            case 1:
                CDamage1.text = PlayerPrefs.GetInt("CmdDmgP11", 0).ToString();
                CDamage2.text = PlayerPrefs.GetInt("CmdDmgP21", 0).ToString();
                CDamage3.text = PlayerPrefs.GetInt("CmdDmgP31", 0).ToString();
                CDamage4.text = PlayerPrefs.GetInt("CmdDmgP41", 0).ToString();
                PCounter.text = PlayerPrefs.GetInt("Poison1", 0).ToString();
                ExpCounter.text = PlayerPrefs.GetInt("Exp1", 0).ToString(); ;
                ComTaxCounter.text = PlayerPrefs.GetInt("Tax1", 0).ToString();
                break;
            case 2:
                CDamage1.text = PlayerPrefs.GetInt("CmdDmgP12", 0).ToString();
                CDamage2.text = PlayerPrefs.GetInt("CmdDmgP22", 0).ToString();
                CDamage3.text = PlayerPrefs.GetInt("CmdDmgP32", 0).ToString();
                CDamage4.text = PlayerPrefs.GetInt("CmdDmgP42", 0).ToString();
                PCounter.text = PlayerPrefs.GetInt("Poison2", 0).ToString();
                ExpCounter.text = PlayerPrefs.GetInt("Exp2", 0).ToString(); ;
                ComTaxCounter.text = PlayerPrefs.GetInt("Tax2", 0).ToString();
                break;
            case 3:
                CDamage1.text = PlayerPrefs.GetInt("CmdDmgP13", 0).ToString();
                CDamage2.text = PlayerPrefs.GetInt("CmdDmgP23", 0).ToString();
                CDamage3.text = PlayerPrefs.GetInt("CmdDmgP33", 0).ToString();
                CDamage4.text = PlayerPrefs.GetInt("CmdDmgP43", 0).ToString();
                PCounter.text = PlayerPrefs.GetInt("Poison3", 0).ToString();
                ExpCounter.text = PlayerPrefs.GetInt("Exp3", 0).ToString(); ;
                ComTaxCounter.text = PlayerPrefs.GetInt("Tax3", 0).ToString();
                break;
            case 4:
                CDamage1.text = PlayerPrefs.GetInt("CmdDmgP14", 0).ToString();
                CDamage2.text = PlayerPrefs.GetInt("CmdDmgP24", 0).ToString();
                CDamage3.text = PlayerPrefs.GetInt("CmdDmgP34", 0).ToString();
                CDamage4.text = PlayerPrefs.GetInt("CmdDmgP44", 0).ToString();
                PCounter.text = PlayerPrefs.GetInt("Poison4", 0).ToString();
                ExpCounter.text = PlayerPrefs.GetInt("Exp4", 0).ToString(); ;
                ComTaxCounter.text = PlayerPrefs.GetInt("Tax4", 0).ToString();
                break;
            default:
                break;
        }
    }
}
