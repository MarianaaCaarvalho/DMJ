using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light light;
    public bool drainOverTime;
    public int maxEnergy;
    public int minEnergy;
    public int drainRate;

    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    void Update()
    {
        light.intensity = Mathf.Clamp(light.intensity, minEnergy, maxEnergy);
        
        if (drainOverTime == true && light.enabled == true) 
        { 
            if (light.intensity > minEnergy) 
            {
                light.intensity -= Time.deltaTime * drainRate;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.B)) 
        { 
            light.enabled = !light.enabled;
        }
    }

    public void AddEnergy(int addedEnergy) 
    { 
        light.intensity += addedEnergy;
    }
}
