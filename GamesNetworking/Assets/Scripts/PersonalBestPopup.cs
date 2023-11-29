using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;

public class PersonalBestPopUp : MonoBehaviour
{
    public GameObject scoreHolderText;
    public GameObject noScoreText;
    
    //All the fields
    public Text userName;
    public Text bestScore;
    public Text date;
    public Text totalPlayers;
    public Text roomName;
    
    public void UpdatePersonalBestUI()
    {
        PlayerData playerData = GameManager.instance.playerData;
        if (playerData.username != null)
        {
            userName.text = playerData.username;
            bestScore.text = playerData.bestScore.ToString();
            date.text = playerData.bestScoreDate;
            totalPlayers.text = playerData.totalPlayersInGame.ToString();
            roomName.text = playerData.roomName;
            
            scoreHolderText.SetActive(true);
            noScoreText.SetActive(false);
        }
        else
        {
            scoreHolderText.SetActive(false);
            noScoreText.SetActive(true);
        }
        
    }

    private void OnEnable()
    {
        UpdatePersonalBestUI();
    }
}

   
