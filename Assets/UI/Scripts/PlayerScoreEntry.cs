using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreEntry : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    public void SetScore(int score, int playerId){
        scoreText.text = $"Player {playerId + 1}: {score}";
    }
}
