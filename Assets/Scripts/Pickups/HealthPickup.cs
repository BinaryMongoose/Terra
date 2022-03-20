using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject pickUp;

    PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = player.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Heal();
        }
    }

    public void Heal()
    {
        if (playerCombat.currentHealth < playerCombat.maxHealth)
        {
            playerCombat.currentHealth += 20;
            Destroy(pickUp);
        }
    }
}
