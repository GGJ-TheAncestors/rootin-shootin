using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private float grabRange;

    [SerializeField]
    private FXObject fx;

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
        Instantiate( fx, transform.position, Quaternion.identity );
        collider.GetComponentInParent<Throw>()?.GO();
    }
}
