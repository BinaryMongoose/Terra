using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller; 
    public Animator animator;
    public HealthBar healthBar; 

    public float runSpeed = 40f;

    public int maxHealth = 100;
    public int currentHealth; 

    float horizontalMove = 0f;
    bool jump = false;
    bool strafe = false; 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true); 
        }

        
        if (Input.GetButtonDown("Strafe"))
        {
            strafe = true; 

        }else if (Input.GetButtonUp("Strafe"))
        {
            strafe = false; 
        }

        // Debug for health
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20); 
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth); 
    }

     void FixedUpdate()
    {

        // Move our character        
        controller.Move(horizontalMove * Time.fixedDeltaTime, strafe, jump);
        jump = false;

    }


}
