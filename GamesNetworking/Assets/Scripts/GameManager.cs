using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using Leguar.TotalJSON;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerData playerData;
    public string filePath;

    private void Start()
    {
        LoadPlayerData();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SavePlayerData()
    {
        //string serialisedDataString = JSON.Serialize(playerData).CreateString();
        //File.WriteAllText(filePath, serialisedDataString);
    }

    public void LoadPlayerData()
    {
        if (!File.Exists(filePath))
        {
            playerData = new PlayerData();
            SavePlayerData();
        }
        
        string fileContents = File.ReadAllText(filePath);
        //playerData = JSON.ParseString(fileContents).Deserialize<PlayerData>();
    }
}
