using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownPanel : MonoBehaviour
{
    [SerializeField] TMP_Text countdownText;
    [SerializeField] TimeLoopController timeLoopController;

    private void OnEnable()
    {
        timeLoopController.RoundStart += HandleRoundStart;
    }

    private void OnDisable()
    {
        timeLoopController.RoundStart -= HandleRoundStart;
    }

    private void Update()
    {
        countdownText.text = "" + timeLoopController.CountDownTimeUI;
    }

    void HandleRoundStart()
    {
        gameObject.SetActive(false);
    }
}
