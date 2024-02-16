using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    GameObject flashlight;
    Light light;

    void Start()
    {
        flashlight = FindObjectOfType<FlashLight>().gameObject;
        light = flashlight.GetComponentInChildren<Light>();
    }

    public void AddEnergy(float addedEnergy)
    {
        light.intensity += addedEnergy;
    }
}
