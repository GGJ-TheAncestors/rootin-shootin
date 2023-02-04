using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private float grabRange;

    public void CheckGrab()
    {
        Collider[] colliders;
        colliders = Physics.OverlapSphere( transform.position, grabRange, mask, QueryTriggerInteraction.Collide);
        
        if( colliders.Length > 0 )
        {
            DoGrab( colliders[0] );
        }
    }

    public void DoGrab( Collider collider )
    {
        collider.GetComponentInParent<Throw>()?.GO();
    }
}
