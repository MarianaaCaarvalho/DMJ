using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable") 
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
                flashlight.SetActive(true);
            }
        }
    }

}
