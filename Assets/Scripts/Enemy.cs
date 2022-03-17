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


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Attack()
    {
        // Creates an array of all objects inside of the attack collider.
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        // if there is anything in the array, call TakeDamage if the object has the method.
        if (hitPlayer.Length > 0)
        {
            // Make sure that you are refrencing the Enemy script
            hitPlayer[0].GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return; }
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

    // Detect if player is in range for attack
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Attack");
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        // Disable Enemy
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
