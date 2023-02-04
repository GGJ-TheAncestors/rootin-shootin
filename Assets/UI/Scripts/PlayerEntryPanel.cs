using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerEntryPanel : MonoBehaviour
{
    [SerializeField] TMP_Text indexText;

    public void SetPlayerInfo(string playerIndex)
    {
        indexText.text = playerIndex;
    }
}
