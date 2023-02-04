using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameEndPanel gameEndPanel;
    [SerializeField] CountdownPanel countdownPanel;

    [SerializeField] GameLoopManager gameLoopManager;


    private void OnEnable()
    {
        gameLoopManager.OnGameComplete += HandleRoundEnd;
        gameLoopManager.GetTimeLoopController().CountdownStart += HandleCountdownStart;
        gameLoopManager.GetTimeLoopController().RoundEnd += HandleRoundEnd;
    }

    private void OnDisable()
    {
        gameLoopManager.OnGameComplete += HandleRoundEnd;
        gameLoopManager.GetTimeLoopController().CountdownStart -= HandleCountdownStart;
        gameLoopManager.GetTimeLoopController().RoundEnd -= HandleRoundEnd;
    }


    void HandleCountdownStart()
    {
        gameEndPanel.gameObject.SetActive(false);
        countdownPanel.gameObject.SetActive(true);
    }

    void HandleRoundEnd()
    {
        gameEndPanel.gameObject.SetActive(true);
    }
}
