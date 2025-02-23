using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabEnter : Interactable
{
    
    void Start()
    {
        promptMessage = "Enter Lab";
    }

    protected override void Interact()
    {
        SceneManager.LoadScene(sceneName: "Dungeon-Lab");
    }
}
