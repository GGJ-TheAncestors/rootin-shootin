using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class RoleManager : MonoBehaviour
{
    readonly List<Characters> AllAvailableCharacters = new() { Characters.Farmer, Characters.Carrot, Characters.Beet, Characters.Onion };

    public int CurrentFarmerID { get; private set; } = 0;
    public List<Characters> PlayerRoles;
    public ReferenceList Players;
    public enum Characters
    {
        Farmer = 0,
        Carrot = 1,
        Beet = 2,
        Onion = 3,
    }

    public Action OnRolesInitialized;
    public Action OnRolesRotated;

    public void InitializeRoles()
    {
        PlayerRoles = new List<Characters>();
        for (int i = 0; i < Players.objects.Count; i++)
        {
            PlayerRoles.Add(AllAvailableCharacters[i]);
        }

        OnRolesInitialized?.Invoke();
    }
 
    public void RotateCharacters()
    {
        // The roles loop around to the next player.
        Characters lastRole = PlayerRoles[PlayerRoles.Count - 1];
        PlayerRoles.Insert(0, lastRole);
        PlayerRoles.RemoveAt(PlayerRoles.Count - 1);


        CurrentFarmerID = CurrentFarmerID == Players.objects.Count ? 0 : CurrentFarmerID + 1;

        OnRolesRotated?.Invoke();
    }

    public bool IsFarmer(int playerID)
    {
        return PlayerRoles.ElementAt(playerID) == Characters.Farmer;
    }

    public Characters GetRole(int playerID)
    {
        return PlayerRoles.ElementAt(playerID);
    }
}