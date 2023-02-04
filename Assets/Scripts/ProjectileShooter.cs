using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public Side side;

    [SerializeField] Projectile projectile;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Fire()
    {
        var newProjectile = Instantiate(projectile, transform.position, transform.rotation, null);
        newProjectile.side = side;
    }
}
