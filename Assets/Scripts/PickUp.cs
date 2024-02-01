using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    public GameObject flashlight;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flashlight") 
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
                flashlight.SetActive(true);
            }
        }

        if (other.gameObject.tag == "Interactable")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
            }
        }
    }

}
