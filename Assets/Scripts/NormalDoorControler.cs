using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDoorControler : MonoBehaviour
{
    public bool shouldOpen = false;
    public GameObject DoorControler;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (DoorControler.GetComponent<doorControler>().shouldOpenExit)
        {
            shouldOpen = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (shouldOpen)
        {
            if (other.CompareTag("Player"))
            {
                animator.SetTrigger("Open");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Closed");
        }
    }
}
