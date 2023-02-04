using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Behaviour")]
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float stopDistance;
    [SerializeField]
    private Vector2 targetVelocity;
    [SerializeField]
    private Vector2 currentVelocity;

    private Rigidbody body;

    void Start()
    {
        enabled = TryGetComponent<Rigidbody>(out body);
    }

    void Update()
    {
        CalculateNewVelocity();
        UpdateVelocity();
    }

    public void SetTargetVelocity( Vector2 velocity )
    {
        targetVelocity = velocity;
    }

    private void CalculateNewVelocity()
    {
        Vector2 steering = currentVelocity - targetVelocity;
        steering *= acceleration;
        steering /= body.mass;

        currentVelocity = Truncate( currentVelocity + steering, maxSpeed );
    }

    private void UpdateVelocity()
    {
        body.velocity = currentVelocity;
    }

    private Vector2 Truncate(Vector2 vector, float maxLength)
    {
        if( vector.sqrMagnitude > maxLength * maxLength )
        {
            return vector.normalized * maxLength;
        }

        return vector;
    }
}