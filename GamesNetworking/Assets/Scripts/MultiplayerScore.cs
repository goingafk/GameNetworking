using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun.UtilityScripts;

public class MultiplayerScore : MonoBehaviourPunCallbacks
{
    public GameObject playerScorePrefab;
    public Transform panel;

    private Dictionary<int, GameObject> playerScore = new Dictionary<int, GameObject>();
    void Start()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            player.SetScore(0);
            var playerScoreObject = Instantiate(playerScorePrefab, panel);
            var playerScoreOjectText = playerScoreObject.GetComponent<Text>();
            playerScoreOjectText.text = string.Format("{0} Score: {1}", player.NickName, player.GetScore());

            playerScore[player.ActorNumber] = playerScoreObject;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer,
        ExitGames.Client.Photon.Hashtable changedProps)
    {
        var playerScoreObject = playerScore[targetPlayer.ActorNumber];
        var playerScoreObjectText = playerScoreObject.GetComponent<Text>();
        playerScoreObjectText.text = string.Format("{0} Score: {1}", targetPlayer.NickName, targetPlayer.GetScore());
    }
}
