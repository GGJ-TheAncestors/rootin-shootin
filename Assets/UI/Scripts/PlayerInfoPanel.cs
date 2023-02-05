using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] Image healthImage;
    [SerializeField] Image ammoImage;
    [SerializeField] TMP_Text playerIdText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image backgroundImage;

    [SerializeField] Sprite farmerBackgroundSprite;
    [SerializeField] Sprite carrotBackgroundSprite;
    [SerializeField] Sprite beetBackgroundSprite;
    [SerializeField] Sprite onionBackgroundSprite;



    public Health playerHealth {get; private set; }

    private void Update()
    {
        if(playerHealth)
        {
            healthImage.fillAmount = playerHealth.GetCurrentHealth() / playerHealth.startHealth;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void SetAmmoFill(float amount)
    {
        ammoImage.fillAmount = amount;
    }

    public void SetHealthFill(float amount)
    {
        healthImage.fillAmount = amount;
    }

    public void SetPlayerId(int playerId)
    {
        playerIdText.text = "" + (playerId + 1);
    }

    public void SetHealthComponent(Health playerHealth)
    {
        this.playerHealth = playerHealth;
    }

    public void SetRole(RoleManager.Characters role)
    {
        switch(role)
        {
            case RoleManager.Characters.Farmer:
                backgroundImage.sprite = farmerBackgroundSprite;
                break;
            case RoleManager.Characters.Carrot:
                backgroundImage.sprite = carrotBackgroundSprite;
                break;
            case RoleManager.Characters.Beet:
                backgroundImage.sprite = beetBackgroundSprite;
                break;
            case RoleManager.Characters.Onion:
                backgroundImage.sprite = onionBackgroundSprite;
                break;
            default:
                break;
        }
    }
}
