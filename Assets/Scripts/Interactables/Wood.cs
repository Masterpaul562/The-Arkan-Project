using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Interactable
{
    public GameObject player;
    void Awake()
    {
        promptMessage = "Pick Up Wood";
      
    }
    protected override void Interact()
    {
        player.GetComponent<PlayerInventory>().IncrementWood();
        Destroy(this.gameObject);
    }
}
