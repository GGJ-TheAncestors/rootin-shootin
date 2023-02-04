using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputsPanel : MonoBehaviour
{
    [SerializeField] PlayerEntryPanel[] playerEntryPanels;
    [SerializeField] ReferenceList controllers;
    [SerializeField] AudioClip controllerAddedSound;
    [SerializeField] AudioClip startGameSound;

    [SerializeField] string mainSceneName = "MainScene";

    int playerCount;

    [SerializeField] InputAction startAction;

    private void OnEnable()
    {
        controllers.OnAdded.AddListener(HandleControllerAdded);
        startAction.performed += HandleStartPerformed;
        startAction.Enable();
    }

    private void OnDisable()
    {
        controllers.OnAdded.RemoveListener(HandleControllerAdded);
        startAction.performed -= HandleStartPerformed;
        startAction.Disable();
    }

    void HandleStartPerformed(InputAction.CallbackContext context)
    {
        StartCoroutine(StartGameRoutine());
    }

    IEnumerator StartGameRoutine()
    {
        AudioSource.PlayClipAtPoint(startGameSound, Vector3.zero);
        yield return new WaitForSeconds(startGameSound.length);
        SceneManager.LoadScene(mainSceneName);
    }

    void HandleControllerAdded(GameObject newController)
    {
        print("controller added ");
        AudioSource.PlayClipAtPoint(controllerAddedSound, Vector3.zero);
        var newInput = newController.GetComponent<PlayerInput>();
        var newPlayerIndex = newInput.playerIndex;
        playerEntryPanels[playerCount].SetPlayerInfo("Player " + newPlayerIndex);
        playerCount++;
    }

    public void TestObject(GameObject thing)
    {
        print("thing" + thing);
    }
}
