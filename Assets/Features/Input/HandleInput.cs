using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInput : MonoBehaviour
{
    [SerializeField]
    private bool possesSelfOnStart = true;

    private Movement movement;
    private ProjectileShooter shooter;
    private Dig dig;
    private Grab grab;

    void Start()
    {
        if( possesSelfOnStart )
            Posses( gameObject );
    }

    public void Posses( GameObject pawn )
    {
        movement = pawn.GetComponentInChildren<Movement>();
        shooter = pawn.GetComponentInChildren<ProjectileShooter>();
        dig = pawn.GetComponentInChildren<Dig>();
        grab = pawn.GetComponentInChildren<Grab>();
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
        float state = value.Get<float>();
        if( dig?.PerformAction( state ) == true )
            movement.SetAccelaration( 1 - state );
    }

    public void OnGrab()
    {
        grab.CheckGrab();
    }

}