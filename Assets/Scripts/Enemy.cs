using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    public LayerMask playerLayer;
    public Transform attackPoint;
    public Collider hitCollider; 

    public int maxHealth = 100;
    int currentHealth;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float invincibleRate = 2;
    float invincibleCool = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Attack()
    {

        // Detect enemies in range of attack
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);


        // Damage them
        // Change so it only detects one collider
        foreach (Collider2D player in hitPlayer)
        {
            
            // Mke sure you are referencing the PlayerMovement script
            player.GetComponent<PlayerMovement>().TakeDamage(attackDamage);
            //Debug.Log(collison.collider.name);  
        }


    }

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack!");
        animator.SetTrigger("Attack");

    }

    void Die()
    {
        // Die Animation
        animator.SetBool("IsDead", true);

        // Disable Enemy
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    }

}
