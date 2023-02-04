using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public float fireRate = 1;

    public Side side;
    public KeyCode fireKey = KeyCode.Space;

    [SerializeField] Projectile projectile;
    [SerializeField] AudioClip fireAudioClip;


    private bool canFire;

    private float fireTimer;

    private void Update()
    {
        if(Input.GetKeyDown(fireKey))
        {
            TryFire();
        }

        if(!canFire)
        {
            fireTimer -= Time.deltaTime;

            if(fireTimer < 0f)
            {
                canFire = true;
                fireTimer = 0f;
            }
        }
    }

    public void TryFire()
    {
        if(canFire)
        {
            Fire();
        }
    }

    public void Fire()
    {
        var newProjectile = Instantiate(projectile, transform.position, transform.rotation, null);
        newProjectile.side = side;
        if(fireAudioClip)
        {
            AudioSource.PlayClipAtPoint(fireAudioClip, transform.position);
        }
        canFire = false;

        fireTimer = 1f / fireRate;
    }


}
