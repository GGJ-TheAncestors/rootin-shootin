using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Character Pool" )]
public class CharacterPool : ScriptableObject
{
    [SerializeField]
    private GameObject farmerPrefab;
    private GameObject farmer;

    [SerializeField]
    private List<GameObject> characters;

    [SerializeField]
    private Queue<GameObject> pooledCharacters;
    private List<GameObject> SpawnedPawns;

    private bool initialized = false;

    private void Initialize()
    {
        GameObject Spawn( GameObject prefab )
        {
            GameObject pawn = Instantiate( prefab );
            pawn.SetActive( false );
            return pawn;
        }   

        farmer = Spawn( farmerPrefab );
        SpawnedPawns.Add( farmer ); 

        for( int i = 0; i < characters.Count; ++i )
        {
            GameObject newPawn = Spawn( characters[i] ) ;
            pooledCharacters.Enqueue( newPawn );
            SpawnedPawns.Add( newPawn );    
        }
    }

    public GameObject GetFarmer()
    {
        if( !initialized )
            Initialize();

        return farmer;
    }

    // Spawn an available character
    public GameObject GetCharacter()
    {
        if( !initialized )
            Initialize();

        pooledCharacters.TryDequeue( out GameObject character );
        return character;
    }

    public void ReleasCharacter(GameObject character )
    {
        character.SetActive( false );
        pooledCharacters.Enqueue( character );
    }
}
