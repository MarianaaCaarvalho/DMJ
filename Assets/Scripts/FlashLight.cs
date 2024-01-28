using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light light;

    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) 
        { 
            light.enabled = !light.enabled;
        }
    }
}
