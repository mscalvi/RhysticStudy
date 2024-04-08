using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;

public class DBBuilder : MonoBehaviour
{
    public string DatabaseName;
    protected string DatabasePath;
    protected SqliteConnection Connection => new SqliteConnection($"Data Source = {DatabasePath};");

    private void Awake()
    {
        DatabaseName = "LifeCounterStats.db";
        DatabasePath = Path.Combine(Application.persistentDataPath, DatabaseName);

        if (string.IsNullOrEmpty(this.DatabaseName))
        {
            Debug.LogError("Empty DB Name!");
            return;
        }

        if (File.Exists(DatabasePath))
        {
            Debug.Log("DB already Exists.");
            Debug.Log(DatabasePath);
        }
        else
        {
            NewDataBase();
            try
            {
                CreateTable();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }

    protected void CreateTable()
    {
        using (var conn = Connection)
        {
            var DeckParameters = $"CREATE TABLE LifeCounterStats" +
                $"(" +
                $"  DeckID INTEGER PRIMARY KEY, " +
                $"  Commander TEXT NOT NULL, " +
                $"  Nickname TEXT NOT NULL, " +
                $"  Creator TEXT NOT NULL, " +
                $"  Archetype TEXT NOT NULL, " +
                $"  Matches INTEGER, " +
                $"  Winrate INTEGER, " +
                $"  Kills INTEGER, " +
                $"  EliminatedPosition REAL, " +
                $"  WinrateAristocrat REAL, " +
                $"  WinrateChaos REAL, " +
                $"  WinrateCombo REAL, " +
                $"  WinrateControl REAL, " +
                $"  WinrateGoWide REAL, " +
                $"  WinrateGroupHug REAL, " +
                $"  WinrateMill REAL, " +
                $"  WinrateStax REAL, " +
                $"  WinrateVoltron REAL" +
                $");";

            conn.Open();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = DeckParameters;
                command.ExecuteNonQuery();
                Debug.Log("Deck Table Ok");
            }
        }
    }

    #region DBCreation

    private void NewDataBase()
    {
        this.DatabasePath = Path.Combine(Application.persistentDataPath, this.DatabaseName);
        SqliteConnection.CreateFile(DatabasePath);
        Debug.Log(DatabasePath);
    }

    #endregion
}
