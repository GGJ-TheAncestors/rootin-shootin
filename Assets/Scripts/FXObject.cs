using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXObject : MonoBehaviour
{
    public float lifeTime = 1f;

    private void Start()
    {
        Invoke(nameof(DestroySelf), lifeTime);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
