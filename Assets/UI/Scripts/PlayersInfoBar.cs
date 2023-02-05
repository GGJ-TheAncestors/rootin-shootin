using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayersInfoBar : MonoBehaviour
{
    [SerializeField] PlayerInfoPanel playerInfoPanelPrefab;
    [SerializeField] RoleManager roleManager;
    [SerializeField] ScoreManager scoreManager;


    private List<PlayerInfoPanel> playerInfoPanels = new List<PlayerInfoPanel>();

    private void OnEnable()
    {
        roleManager.OnRolesInitialized += HandleRolesInitialized;
        roleManager.OnRolesRotated += HandleRolesRotated;
        scoreManager.ScoreAction += HandleScoreUpdate;
    }

    private void OnDisable()
    {
        roleManager.OnRolesInitialized -= HandleRolesInitialized;
        roleManager.OnRolesRotated -= HandleRolesRotated;
        scoreManager.ScoreAction -= HandleScoreUpdate;


    }


    public void AddPlayer(int playerId, RoleManager.Characters role)
    {
        var newPlayerInfoPanel = Instantiate(playerInfoPanelPrefab, transform);
        newPlayerInfoPanel.SetPlayerId(playerId);
        newPlayerInfoPanel.SetRole(role);
        playerInfoPanels.Add(newPlayerInfoPanel);
    }

    public void RemovePlayer(Health playerToRemove)
    {
        var panelToRemove = playerInfoPanels.First(x => playerToRemove == x.player);

        playerInfoPanels.Remove(panelToRemove);
        Destroy(panelToRemove.gameObject);
    }

    void HandleRolesInitialized()
    {
        for(int i = 0; i < roleManager.PlayerRoles.Count; i++)
        {
            AddPlayer(i, roleManager.PlayerRoles[i]);
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
        playerInfoPanels[playerId].SetScore(score);
    }
}
