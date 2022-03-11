using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject heartPrefab;
    public int Hearts = 3;

    public float HeartX = 800;
    public float HeartY = 100; 

    [SerializeField] bool Damaged = false; 
 
    // Start is called before the first frame update
    void Start()
    {
        //GameObject Heart = GameObject.Instantiate(heartPrefab, new Vector3(HeartX, HeartY, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

        for (int i = 0; i < Hearts; i++ )
        {
            GameObject Heart = GameObject.Instantiate(heartPrefab, new Vector3(HeartX, HeartY, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            HeartX += 50;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Damaged == true)
        {
            Hearts -= 1;
            Destroy(heartPrefab); 
        }

    }
}
