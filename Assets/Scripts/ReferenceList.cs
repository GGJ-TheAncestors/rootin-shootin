using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ReferenceList")]
public class ReferenceList : ScriptableObject
{
    public List<GameObject> objects;

    public UnityEvent<GameObject> OnAdded;

    public void Clear()
    {
        OnAdded.RemoveAllListeners();
        objects = new List<GameObject>();
    }

    public void Add( GameObject obj )
    {
        if( objects == null )
            objects = new List<GameObject>();

        objects.Add( obj );
        OnAdded.Invoke( obj );
    }

    public void Remove( GameObject obj )
    {
        objects.Remove( obj );
        
    }
}
