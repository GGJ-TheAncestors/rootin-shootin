using System;
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
    private Vector2 targetVelocity;
    [SerializeField]
    private Vector2 currentVelocity;

    private Rigidbody body;
    private Animator anim;

    void Start()
    {
        enabled = TryGetComponent<Rigidbody>(out body);
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CalculateNewVelocity();
        UpdateVelocity();
    }

    public void SetTargetVelocity( Vector2 velocity )
    {
        targetVelocity = velocity * maxSpeed;
    }

    public Vector2 GetTargetVelocity() => targetVelocity;

    private void CalculateNewVelocity()
    {
        Vector2 steering = targetVelocity - currentVelocity;
        steering *= acceleration;
        steering /= body.mass;

        currentVelocity = Truncate( currentVelocity + steering, maxSpeed );
    }

    private void UpdateVelocity()
    {
        // Vector3 forward = new Vector3(targetVelocity.x, 0, targetVelocity.y).normalized;
        // if( forward.sqrMagnitude > 0 )
        //     transform.forward = forward;
        if( currentVelocity.sqrMagnitude > 0 )
        {
            anim.SetFloat( "DirectionX", currentVelocity.x );
            anim.SetFloat( "DirectionY", currentVelocity.y );
        }

        body.velocity = new Vector3(currentVelocity.x, body.velocity.y, currentVelocity.y);
    }

    private Vector2 Truncate(Vector2 vector, float maxLength)
    {
        if( vector.sqrMagnitude > maxLength * maxLength )
        {
            return vector.normalized * maxLength;
        }

        return vector;
    }

    public void SetAccelaration(float newAcceleration)
    {
        acceleration = newAcceleration;
        if( newAcceleration == 0 )
            Break();
    }

    public void Break()
    {
        currentVelocity *= 0.0f;
    }
}