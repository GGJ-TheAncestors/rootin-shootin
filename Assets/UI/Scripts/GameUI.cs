using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameEndPanel gameEndPanel;

    [SerializeField] GameLoopManager gameLoopManager;


    private void OnEnable()
    {
        gameLoopManager.OnGameComplete += HandleRoundEnd;
    }

    private void OnDisable()
    {
        gameLoopManager.OnGameComplete += HandleRoundEnd;
    }

    void HandleRoundEnd()
    {
        gameEndPanel.gameObject.SetActive(true);
    }
}
