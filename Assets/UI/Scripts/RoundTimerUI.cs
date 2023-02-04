using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundTimerUI : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] Slider timerSlider;
    [SerializeField] TimeLoopController timeLoopController;

    private float timerMax = 1f;

    private void OnEnable()
    {
        timerMax = timeLoopController.RoundTimeUI;
    }

    private void Update()
    {
        timerSlider.value = timeLoopController.RoundTimeUI / timerMax;
        timerText.text = "" + timeLoopController.RoundTimeUI;
    }
}
