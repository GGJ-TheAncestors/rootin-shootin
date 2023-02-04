using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInput : MonoBehaviour
{
    private Movement movement;

    void Start()
    {
        enabled = TryGetComponent<Movement>( out movement );
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        movement.SetTargetVelocity( direction );
    }

    public void OnShoot( InputValue value )
    {

    }

    public void OnDig( InputValue value )
    {

    }
    
}