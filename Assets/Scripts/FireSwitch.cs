using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject sun;
    [SerializeField]
    private GameObject particle;
    // Update is called once per frame
    void Update()
    {
        
        if (sun.GetComponent<DayNightCycle>().isDay == true)
        {
            particle.SetActive(false);
        }else { particle.SetActive(true); }
    }
}
