using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;
    public GameObject self;

    PlayerInteractions playerInteractions;

    // Start is called before the first frame update
    void Start()
    {
        playerInteractions = player.GetComponent<PlayerInteractions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Ayo");
            CoinPickup();
        }
    }

    public void CoinPickup()
    {
        playerInteractions.AddCash(10);
        Destroy(self);
    }
}
