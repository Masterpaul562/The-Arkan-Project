using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Interactable
{
    public GameObject player; 
    void Awake()
    {
        promptMessage = "Pick Up Rock";
       
    }
    protected override void Interact()
    {
        player.GetComponent<PlayerInventory>().IncrementStone();
        Destroy(this.gameObject);        
    }
}
