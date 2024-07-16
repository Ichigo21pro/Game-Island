using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{

    public static Action<bool> IsInGround;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float coyote_time, jump_time=0.2f;
    [SerializeField] private float coyote_time_buffering, jump_time_buffering;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int number_jumps,reset_jumps = 1;
    [SerializeField] private Vector2 velocity = new Vector2(0.1f,0.1f);
    [SerializeField] private Transform ground_check,right_wall_check,left_wall_check;
    [SerializeField] private LayerMask ground_layer,wall_layer;
    [SerializeField] private float movemtent_speed = 0.1f;
    [SerializeField] private float jumping_force = 10f;
    [SerializeField] private bool CanWallJump = false;

    private void OnEnable()
    {
        GameManger.DamageChanged += OnDeath;
    }
    private void OnDisable()
    {
        GameManger.DamageChanged -= OnDeath;   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Ground())
        {
            coyote_time_buffering = coyote_time;
        }
        else
        {
            coyote_time_buffering -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump_time_buffering= jump_time;
        }
        else
        {
            jump_time_buffering -=Time.deltaTime;
        }

        if (jump_time_buffering>0f&& (coyote_time_buffering>0f||number_jumps>0))
        {
           
            if (coyote_time_buffering <= 0f)
            {
                
            }
            jump_time_buffering = 0;
            rb.gravityScale = 1f;
            float xVelocity = rb.velocity.x;

            if (TouchingWall().isTouchingWall&&TouchingWall().isRight&&!Ground()) {
                rb.AddForce(Vector2.left * 500,ForceMode2D.Force);
            }
            else if (TouchingWall().isTouchingWall && !TouchingWall().isRight && !Ground())
            {
                rb.AddForce(Vector2.right * 500, ForceMode2D.Force);
            }
           
            rb.velocity = new Vector2(xVelocity,jumping_force);
           
        }

        if (Input.GetButtonUp("Jump")&&rb.velocity.y>0f)
        {
            number_jumps = --number_jumps;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y*0.5f); 
        }

        if (rb.velocity.y < 0f && rb.velocity.y > -10f&& !Ground()) {
            rb.gravityScale = 4f;
        }
        else if (Ground()||(!Ground()&&TouchingWall().isTouchingWall)) {
            coyote_time_buffering = coyote_time;
            number_jumps = reset_jumps;
            rb.gravityScale = 1f;
        }
      


        float targetSpeed= Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, new Vector2(targetSpeed, rb.velocity.y),ref velocity,movemtent_speed );
        if (Input.GetAxisRaw("Horizontal") < 0 )
        {
            
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 )
        {
           
            spriteRenderer.flipX = false;
        }

    }

    bool Ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(ground_check.position, Vector2.down,0.1f, ground_layer);
       
        if (hit.collider != null)
        {
            IsInGround?.Invoke(true);
        }
        else
        {
            IsInGround?.Invoke(false);
        }

        return hit.collider!=null;
    }

    (bool isTouchingWall, bool isRight) TouchingWall()
    {
        if (CanWallJump) { 
        RaycastHit2D hitLeft = Physics2D.Raycast(left_wall_check.position, Vector2.left, 0.1f, ground_layer);
        RaycastHit2D hitRight = Physics2D.Raycast(right_wall_check.position, Vector2.right, 0.1f, ground_layer);
        if (hitLeft.collider != null)
        {
            return (true, false);
        }
        if( hitRight.collider != null)
        {
            return (true, true); ;
        }
        }
        return (false, false); ;
    }

    public void NumberOfJumps(int jumps)
    {
        reset_jumps = jumps;
    }
    void OnDeath(bool death)
    {
        rb.velocity= Vector2.zero;
    }
}
