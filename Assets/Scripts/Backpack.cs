using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour
{
    public GameObject inventoryCanvas;
    private bool isShowing;

    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        myText.text = "Hello World!";
        inventoryCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            isShowing = !isShowing;
            inventoryCanvas.SetActive(isShowing);
        }
    }

    public void Click()
    {
        isShowing = !isShowing;
        inventoryCanvas.SetActive(isShowing);
    }


}
