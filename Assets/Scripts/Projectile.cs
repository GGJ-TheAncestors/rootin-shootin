using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;
    public float speed = 10f;
    public float lifeTime = 5f;
    public Side side;

    [SerializeField] FXObject hitFX;

    private void Start()
    {
        Invoke("DestroySelf", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void DestroySelf()
    {
        Destroy(gameObject);
        if(hitFX)
        {
            Instantiate(hitFX, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherHealth = other.GetComponent<Health>();

        if(otherHealth)
        {
            if(side != otherHealth.side)
            {
                otherHealth.TakeDamage(damage);
                DestroySelf();

            }
        }
    }
}
