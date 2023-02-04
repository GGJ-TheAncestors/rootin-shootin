using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : MonoBehaviour
{
    public int CurrentFarmerID { get; private set; } = 0;
    public int PlayerCount = 4; // TODO: Player manager? Player pool? Find out how many players there actually are.

    // Switch to the next farmer.
    public void NextFarmer()
    {
        // Increment current farmer.
        CurrentFarmerID = CurrentFarmerID == 4 ? 0 : CurrentFarmerID + 1;
    }

    public bool IsFarmer(int playerID)
    {
        return playerID == CurrentFarmerID;
    }

    public void Reset()
    {
        CurrentFarmerID = 0;
    }
}