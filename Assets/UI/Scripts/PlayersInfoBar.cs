using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayersInfoBar : MonoBehaviour
{
    [SerializeField] PlayerInfoPanel playerInfoPanelPrefab;
    [SerializeField] RoleManager roleManager;


    private List<PlayerInfoPanel> playerInfoPanels = new List<PlayerInfoPanel>();

    private void OnEnable()
    {
        roleManager.OnRolesInitialized += HandleRolesInitialized;
    }


    public void AddPlayer()
    {
        var newPlayerInfoPanel = Instantiate(playerInfoPanelPrefab, transform);
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
            AddPlayer();
        }
    }
}
