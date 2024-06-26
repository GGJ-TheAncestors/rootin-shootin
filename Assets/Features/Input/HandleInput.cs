using UnityEngine;
using UnityEngine.InputSystem;

public class HandleInput : MonoBehaviour
{
    public GameObject pawn;

    [SerializeField]
    private bool possesSelfOnStart = true;

    private Movement movement;
    private ProjectileShooter shooter;
    private Dig dig;
    private Grab grab;

    void Start()
    {
        DontDestroyOnLoad( this.gameObject );        

        if( possesSelfOnStart )
            Posses( gameObject );
    }

    [ContextMenu("Posses Current")]
    public void Posses()
    {
        movement = pawn.GetComponentInChildren<Movement>();
        shooter = pawn.GetComponentInChildren<ProjectileShooter>();
        dig = pawn.GetComponentInChildren<Dig>();
        grab = pawn.GetComponentInChildren<Grab>();
    }

    public void Posses( GameObject pawn )
    {
        PlayerInput input = GetComponent<PlayerInput>();
        if( input.devices.Count == 1 && input.currentControlScheme.ToLower() != "controller" )
            return; // do not posses invalid player setup


        this.pawn = pawn;
        Posses();
    }

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        movement?.SetTargetVelocity( direction );
    }

    public void OnShoot( InputValue value )
    {
        shooter?.TryFire();
    }

    public void OnDig( InputValue value )
    {
        float state = value.Get<float>();
        if( dig?.PerformAction( state ) == true )
            movement.SetAccelaration( 1 - state );
    }

    public void OnGrab()
    {
        grab?.CheckGrab();
    }

}