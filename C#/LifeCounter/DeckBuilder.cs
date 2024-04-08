using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckBuilder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ArcDescription;

    [SerializeField] private Button a01b;
    [SerializeField] private Button a02b;
    [SerializeField] private Button a03b;
    [SerializeField] private Button a04b;
    [SerializeField] private Button a05b;
    [SerializeField] private Button a06b;
    [SerializeField] private Button a07b;
    [SerializeField] private Button a08b;
    [SerializeField] private Button a09b;

    private int ArchetypeSelector;
    private string ArchetypeSelected;
    private Color ActiveColor;
    private Color BaseColor;

    [SerializeField] private TMP_InputField Commander;
    [SerializeField] private TMP_InputField Nickname;
    [SerializeField] private TMP_InputField Creator;

    private GameObject ConfirmPanel;

    void Start()
    {
        ConfirmPanel = GameObject.FindWithTag("ConfirmPanel");
        ConfirmPanel.SetActive(false);

        ActiveColor = new Color (162f/202f, 0f, 0f);
        BaseColor = Color.white;
        a01f();
    }

    public void ConfirmDeck()
    {
        PlayerPrefs.SetString("Commander", Commander.text);
        PlayerPrefs.SetString("Nickname", Nickname.text);
        PlayerPrefs.SetString("Creator", Creator.text);
        switch (ArchetypeSelector)
        {
            case 1: ArchetypeSelected = "Aristocrat"; break;
            case 2: ArchetypeSelected = "Chaos"; break;
            case 3: ArchetypeSelected = "Combo"; break;
            case 4: ArchetypeSelected = "Control"; break;
            case 5: ArchetypeSelected = "GoWide"; break;
            case 6: ArchetypeSelected = "GroupHug"; break;
            case 7: ArchetypeSelected = "Mill"; break;
            case 8: ArchetypeSelected = "Voltron"; break;
            case 9: ArchetypeSelected = "Stax"; break;
        }
        PlayerPrefs.SetString("Archetype", ArchetypeSelected);
        ConfirmPanel.SetActive(true);
    }

    public void Return()
    {
        SceneManager.LoadScene("DecksDatabase");
    }


    #region ArchetypeRegion

    public void a01f ()
    {
        ArchetypeSelector = 1;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Aristocrat");
        ArcDescription.text = "Aristocrats: decks that use cards like Blood Artist to generate a small life drain effect, potentiated with tokens and recursion.";
    }

    public void a02f()
    {
        ArchetypeSelector = 2;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Chaos");
        ArcDescription.text = "Chaos: decks that use cards like Possibility Storm to generate chaos and take advantage of it.";
    }

    public void a03f()
    {
        ArchetypeSelector = 3;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Combo");
        ArcDescription.text = "Combo: decks that utilize infinite combo strategies to win in a single round.";
    }

    public void a04f()
    {
        ArchetypeSelector = 4;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Control");
        ArcDescription.text = "Control: decks that employ extensive interaction, such as removal and counterspells.";
    }

    public void a05f()
    {
        ArchetypeSelector = 5;
        Colorize();
        PlayerPrefs.SetString("Archetype", "GoWide");
        ArcDescription.text = "Go Wide: decks that aim to establish a large board presence, often featuring a plethora of permanents, such as Slivers, to overwhelm their opponents.";
    }

    public void a06f()
    {
        ArchetypeSelector = 6;
        Colorize();
        PlayerPrefs.SetString("Archetype", "GroupHug");
        ArcDescription.text = "Group Hug: decks that employ friendly effects, sharing draws and utility cards, aiming to form alliances.";
    }

    public void a07f()
    {
        ArchetypeSelector = 7;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Mill");
        ArcDescription.text = "Mill: decks that aim to deplete the opponent's library, either by milling or exiling their resources before they can be used.";
    }

    public void a08f()
    {
        ArchetypeSelector = 8;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Voltron");
        ArcDescription.text = "Voltron: decks that employ a tall creature strategy, utilizing auras or equipment and focusing on dealing commander damage.";
    }

    public void a09f()
    {
        ArchetypeSelector = 9;
        Colorize();
        PlayerPrefs.SetString("Archetype", "Stax");
        ArcDescription.text = "Stax: decks that aim to stabilize the board state by disrupting opponents' strategies and resources.";
    }

    private void Colorize()
    {
        switch (ArchetypeSelector)
        {
            case 1:
                a01b.image.color = ActiveColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 1");
                break;
            case 2:
                a01b.image.color = BaseColor;
                a02b.image.color = ActiveColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 2");
                break;
            case 3:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = ActiveColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 3");
                break;
            case 4:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = ActiveColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 4");
                break;
            case 5:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = ActiveColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 5");
                break;
            case 6:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = ActiveColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 6");
                break;
            case 7:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = ActiveColor;
                a08b.image.color = BaseColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 7");
                break;
            case 8:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = ActiveColor;
                a09b.image.color = BaseColor;
                Debug.Log("Pintei 8");
                break;
            case 9:
                a01b.image.color = BaseColor;
                a02b.image.color = BaseColor;
                a03b.image.color = BaseColor;
                a04b.image.color = BaseColor;
                a05b.image.color = BaseColor;
                a06b.image.color = BaseColor;
                a07b.image.color = BaseColor;
                a08b.image.color = BaseColor;
                a09b.image.color = ActiveColor;
                Debug.Log("Pintei 9");
                break;
        default: break;
        }
    }

    #endregion
}