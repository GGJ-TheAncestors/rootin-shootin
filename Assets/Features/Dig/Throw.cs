using UnityEngine;

public class Throw : MonoBehaviour
{
    public float throwHeight;
    public float stunTime;
    public float time;

    public Animator anim;
    public Rigidbody body;
    public Movement movement;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        body = GetComponentInChildren<Rigidbody>();
        movement = GetComponentInChildren<Movement>();
    }

    void OnValidate()
    {
        Start();
    }

    void Update()
    {
        time -= Time.deltaTime;

        if( time <= 0 )
        {
            body.useGravity = false;
            body.position = new Vector3( body.position.x, 0, body.position.z );
            body.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }

        if( time <= -stunTime )
        {
            movement.enabled = true;
            enabled = false;
        }
    }
    
    public void GO()
    {
        body.constraints = RigidbodyConstraints.FreezeRotation;
        
        enabled = true;
        anim.SetBool("Action_Dig", false );
        
        float up = Mathf.Sqrt( -2*Physics.gravity.y * throwHeight );
        time = Mathf.Sqrt( -(2*throwHeight/Physics.gravity.y) ) + Mathf.Sqrt( -(2*throwHeight/Physics.gravity.y) );
        
        body.velocity = new Vector3( body.velocity.x, up, body.velocity.z );
        body.useGravity = true;
        
        movement.enabled = false;
    }
}
