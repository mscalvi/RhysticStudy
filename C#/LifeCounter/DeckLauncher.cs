using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckLauncher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CommanderText;
    [SerializeField] private TextMeshProUGUI NicknameText;
    [SerializeField] private TextMeshProUGUI CreatorText;
    [SerializeField] private TextMeshProUGUI ArchetypeText;

    private GameObject ConfirmPanel;

    private string databasePath;
    private SqliteConnection Connection => new SqliteConnection($"Data Source = {databasePath};");

    void OnEnable()
    {
        CommanderText.text = "Commander: " + PlayerPrefs.GetString("Commander");
        NicknameText.text = "Display Name: " + PlayerPrefs.GetString("Nickname");
        CreatorText.text = "Deck Creator: " + PlayerPrefs.GetString("Creator");
        ArchetypeText.text = "Deck Archetype: " + PlayerPrefs.GetString("Archetype");
    }

    void Start ()
    {
        ConfirmPanel = GameObject.FindWithTag("ConfirmPanel");

        string databaseName = "LifeCounterStats.db";
        string persistentDataPath = Application.persistentDataPath;
        databasePath = Path.Combine(persistentDataPath, databaseName);

        // Verifique se o banco de dados existe
        if (!File.Exists(databasePath))
        {
            Debug.LogError("O banco de dados não existe no caminho especificado: " + databasePath);
            return;
        }
    }

    public void EditDeck ()
    {
        ConfirmPanel.SetActive(false);
    }

    public void ConfirmDeck()
    {
        CreateDeck (PlayerPrefs.GetString("Commander"), PlayerPrefs.GetString("Nickname"), PlayerPrefs.GetString("Creator"), PlayerPrefs.GetString("Archetype"));
    }

    public void CreateDeck (string Commander, string DeckNickname, string Creator, string Archetype)
    {
        var commandText = "INSERT INTO LifeCounterStats(Commander, Nickname, Creator, Archetype) VALUES (@commander, @decknickname, @creator, @archetype);";

        using (var connection = Connection)
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = commandText;
                command.Parameters.AddWithValue("@commander", PlayerPrefs.GetString("Commander"));
                command.Parameters.AddWithValue("@decknickname", PlayerPrefs.GetString("Nickname"));
                command.Parameters.AddWithValue("@creator", PlayerPrefs.GetString("Creator"));
                command.Parameters.AddWithValue("@archetype", PlayerPrefs.GetString("Archetype"));

                var result = command.ExecuteNonQuery();
                Debug.Log($"Rows affected: {result}");
            }
        }
    }
}
