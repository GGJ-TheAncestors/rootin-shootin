using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> CharacterPrefabs = new();
    [SerializeField]
    private List<GameObject> PlayerCharacters = new();
    [SerializeField]
    private List<Transform> SpawnPositions = new();
    [SerializeField]
    private RoleManager Roles;
    [SerializeField]
    private ReferenceList Players;

    public Action OnCharactersInstantiated;

    public List<GameObject> GetPlayerCharacters() => PlayerCharacters;

    public void InstantiateCharacters()
    {
        for (int i = 0; i < Players.objects.Count; i++)
        {
            // For each player, spawn the object that they're playing as this round in their spawn position.
            RoleManager.Characters role = Roles.GetRole(i);
            PlayerCharacters.Add(Instantiate(CharacterPrefabs[(int)role]));
            PlayerCharacters[i].transform.position = SpawnPositions[i].position;

            // Assign control of the gameobject.
            HandleInput handleInput = Players.objects[i].GetComponent<HandleInput>();
            handleInput.Posses(PlayerCharacters[i]);
        }

        OnCharactersInstantiated?.Invoke();
    }

    public void ClearCharacters()
    {
        foreach(GameObject character in PlayerCharacters) {
            Destroy(character);
        }
        PlayerCharacters.Clear();
    }
}
