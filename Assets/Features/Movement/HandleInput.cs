using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInput : MonoBehaviour
{
    private Movement movement;
    private ProjectileShooter shooter;

    void Start()
    {
        TryGetComponent<Movement>( out movement );
        shooter = GetComponentInChildren<ProjectileShooter>();
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        movement?.SetTargetVelocity( direction );
    }

    public void OnShoot( InputValue value )
    {
        shooter?.Fire();
    }

    public void OnDig( InputValue value )
    {

    }

}