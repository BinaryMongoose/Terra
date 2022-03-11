using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    public LayerMask enemyLayers; 

    public Animator animator;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public int attackDamage = 40;


    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Play an attack Animation
                animator.SetTrigger("Attack");
            }
    }

    void Attack()
    {
        
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            // Make sure that you are refrencing the Enemy script
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return; 

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }

}
