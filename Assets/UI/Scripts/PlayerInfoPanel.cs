using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] Image healthImage;
    [SerializeField] Image ammoImage;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scoreText;

    public Health player {get; private set; }

    public void Initialize(Health playerHealth, ProjectileShooter projectileShooter)
    {
        player = playerHealth;
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }
}
