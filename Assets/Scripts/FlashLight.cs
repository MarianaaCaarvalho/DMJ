using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    Light light;
    public bool drainOverTime;
    public int maxEnergy;
    public int minEnergy;
    public int drainRate;
    public Slider lightSlider;
    public Inventory _inventory;

    void Start()
    {
        _inventory = GameObject.Find("First Person Controller").GetComponent<Inventory>();
        light = GetComponentInChildren<Light>();
        lightSlider.maxValue = light.intensity;
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

        lightSlider.value = light.intensity;

        if (Input.GetKeyDown(KeyCode.B)) 
        { 
            light.enabled = !light.enabled;
        }
    }

    public void AddEnergy(int addedEnergy)
    {
        if (_inventory.inventorySlots == null) return;

        else
        {
            for (int i = 0; i < _inventory.inventorySlots.Count; i++)
            {

                light.intensity += addedEnergy;
            }
            
        }
    }
}
