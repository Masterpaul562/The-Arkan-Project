using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screaming : Interactable
{
    [SerializeField] private AudioClip scream;
    private AudioSource audioSource;
    void Start()
    {
        promptMessage = "You hear Screams";
        audioSource = GetComponent<AudioSource>();
    }

   protected override void Interact()
    {
        audioSource.clip = scream;
        audioSource.Play();
    }
}
