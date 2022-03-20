using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller; 
    public Animator animator;


    public float runSpeed = 40f;



    float horizontalMove = 0f;
    bool jump = false;
    bool strafe = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (PauseControl.gameIsPaused == false) {

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Strafe"))
            {
                strafe = true;

            }
            else if (Input.GetButtonUp("Strafe"))
            {
                strafe = false;
            }
        } else
        {
            Debug.Log("The game is Paused!");
        }
    }

     public void OnLanding ()
     {
        animator.SetBool("IsJumping", false);
     }

    public void OnStrafing (bool IsStrafing)
    {
        animator.SetBool("IsStrafing", IsStrafing);
    }



     void FixedUpdate()
    {

        // Move our character        
        controller.Move(horizontalMove * Time.fixedDeltaTime, strafe, jump);
        jump = false;

    }


}
