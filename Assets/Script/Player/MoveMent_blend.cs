
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent_blend : MonoBehaviour
{
    
    //private fields :
    float horizontal_value;
    bool isRunning;
    private bool IsCrouching;
    
 

    // Components :
    private Rigidbody2D rb;
    private SpriteRenderer render;
    private Animator anim;
    [SerializeField] BoxCollider2D collider2D;
    [SerializeField] LayerMask ground;
    
    
    //Public fields :
    public float speed;
    public float RunningSpeed;
    public float Jump_force;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
        Sound_Manager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //Crouch..................................................................................................................
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        { IsCrouching = false; }

        horizontal_value = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(rb.velocity.x)>=2f && !isRunning )
        {
            Sound_Manager.instance.PlayerSound(Sound_Manager.PlayerSoundFX.PlayerWalk);
        }
        
        else if (Mathf.Abs(rb.velocity.x) >= 6f && isRunning)
        {
            Sound_Manager.instance.PlayerSound(Sound_Manager.PlayerSoundFX.PlayerRun);
        }
        //For sprint/Run........................................................................................................
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
          

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
           
        }

      

       
            


    }

    private void FixedUpdate()
    {  
        move(horizontal_value);     
    }


    void move(float direction)
    {
        if (!IsCrouching)
        {
            float Xval = direction * speed * 100 * Time.deltaTime;

            if (isRunning)
            {
                Xval *= RunningSpeed;
                

            }
           
            Vector2 Velocity = new Vector2(Xval, rb.velocity.y);
            rb.velocity = Velocity;

            

            if (Xval > 0f)
            {
                render.flipX = false;
            }
            else if (Xval < 0f)
            {
                render.flipX = true;
            }
            anim.SetFloat("XVelocity", Mathf.Abs(rb.velocity.x));
            Debug.Log(rb.velocity.x);
        }

    }
  
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, .1f, ground);
    }
}