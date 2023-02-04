using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayersInfoBar : MonoBehaviour
{
    [SerializeField] PlayerInfoPanel playerInfoPanelPrefab;

    private List<PlayerInfoPanel> playerInfoPanels = new List<PlayerInfoPanel>();

    public void AddPlayer(Health health, ProjectileShooter projectileShooter)
    {
        var newPlayerInfoPanel = Instantiate(playerInfoPanelPrefab, transform);
        newPlayerInfoPanel.Initialize(health, projectileShooter);
        playerInfoPanels.Add(newPlayerInfoPanel);
    }

    public void RemovePlayer(Health playerToRemove)
    {
        var panelToRemove = playerInfoPanels.First(x => playerToRemove == x.player);

        playerInfoPanels.Remove(panelToRemove);
        Destroy(panelToRemove.gameObject);

    }
}
