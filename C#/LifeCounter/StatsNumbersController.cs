using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class StatsNumbersController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TextMeshProUGUI ValueText;

    private bool Holding;
    private bool Incrementing;
    private float holdTimer = 0f;
    private float holdDuration = 1.5f;
    private int Value;

    private string SelectedObject;
    private int AlteredValue;
    private string AlteredText;

 /*   void OnEnable()
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
    }*/

    void Update()
    {
        if (Holding)
        {
            holdTimer += Time.deltaTime;
            if (holdTimer >= holdDuration)
            {
                ValueText.text = "0";
                holdTimer = 0f;
                AlteredValue = 0;
                SaveValue();
            }
        }

        if (Incrementing)
        {
            Value = int.Parse(ValueText.text);
            Value++;
            ValueText.text = Value.ToString();
            Incrementing = false;
            AlteredValue = Value;
            SaveValue();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Incrementing = true;
        Holding = true;
        holdTimer = 0f; 
        SelectedObject = gameObject.name;
        Debug.Log (SelectedObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Incrementing = false;
        Holding = false;
    }

    public void SaveValue()
    {
        AlteredText = SelectedObject + GameController.ActivePlayer;
        PlayerPrefs.SetInt(AlteredText, AlteredValue);
        Debug.Log(AlteredText);
        Debug.Log(AlteredValue);
    }

}
