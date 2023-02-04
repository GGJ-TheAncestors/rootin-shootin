using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ReferenceList")]
public class ReferenceList : ScriptableObject
{
    public List<GameObject> objects;

    public void Clear()
    {
        objects = new List<GameObject>();
    }

    public void Add( GameObject obj )
    {
        if( objects == null )
            objects = new List<GameObject>();

        objects.Add( obj );
    }

    public void Remove( GameObject obj )
    {
        objects.Remove( obj );
    }
}
