using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayersInfoBar : MonoBehaviour
{
    [SerializeField] PlayerInfoPanel playerInfoPanelPrefab;
    [SerializeField] RoleManager roleManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] CharacterManager characterManager;
   


    private List<PlayerInfoPanel> playerInfoPanels = new List<PlayerInfoPanel>();

    private void OnEnable()
    {
        roleManager.OnRolesRotated += HandleRolesRotated;
        scoreManager.ScoreAction += HandleScoreUpdate;
        characterManager.OnCharactersInstantiated += HandleCharactersInstantiated;
    }

    private void OnDisable()
    {
        roleManager.OnRolesRotated -= HandleRolesRotated;
        scoreManager.ScoreAction -= HandleScoreUpdate;
    }

    public void AddPlayer(int playerId, RoleManager.Characters role, Health playerHealth)
    {
        var newPlayerInfoPanel = Instantiate(playerInfoPanelPrefab, transform);
        newPlayerInfoPanel.SetPlayerId(playerId);
        newPlayerInfoPanel.SetRole(role);
        newPlayerInfoPanel.SetHealthComponent(playerHealth);
        newPlayerInfoPanel.SetScore(scoreManager.GetPlayerScores()[playerId]);
        playerInfoPanels.Add(newPlayerInfoPanel);
    }

    void HandleCharactersInstantiated()
    {
        //Destroy all current panels
        foreach(var playerInfoPanel in playerInfoPanels)
        {
            playerInfoPanel.gameObject.SetActive(false);
        }
        playerInfoPanels.Clear();

        var playerCharacters = characterManager.GetPlayerCharacters();

        for(int i = 0; i < roleManager.PlayerRoles.Count; i++)
        {
            var currentPlayerHealth = playerCharacters[i].GetComponent<Health>();
            print($"health is {currentPlayerHealth}");
            AddPlayer(i, roleManager.PlayerRoles[i], currentPlayerHealth);
        }
    }

    void HandleRolesRotated()
    {
        for(int i = 0; i < playerInfoPanels.Count; i++)
        {
            playerInfoPanels[i].SetRole(roleManager.PlayerRoles[i]);
        }
    }

    void HandleScoreUpdate(int score, int playerId)
    {
        if(playerInfoPanels.Count != 0)
        {
            playerInfoPanels[playerId].SetScore(score);
        }
    }
}
