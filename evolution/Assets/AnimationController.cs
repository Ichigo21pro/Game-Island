using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    
    bool isGrounded;
    public static event Action<bool> StopAll;
    private void OnEnable()
    {
        GameManger.DamageChanged += ManIamDead;
        controls.IsInGround += IsGround;
    }

    private void OnDisable()
    {
        GameManger.DamageChanged -= ManIamDead;
        controls.IsInGround -= IsGround;
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && isGrounded)
        {
            animator.SetBool("Running", true);
          
        }
        else if(Input.GetAxisRaw("Horizontal") > 0 && isGrounded)
        {
            animator.SetBool("Running", true);
           
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetButtonDown("Jump") || !isGrounded)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }
    void IsGround(bool ground)
    {
        isGrounded = ground;
    }
    void ManIamDead(bool death) {

        StopAll?.Invoke(true);
        animator.SetTrigger("Death");
    }
}
