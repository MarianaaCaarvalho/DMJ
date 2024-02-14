using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUp : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flashImage;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flashlight")
        {
            if (Input.GetKey(KeyCode.F))
            {
                Destroy(other.gameObject);
                flashlight.SetActive(true);
                flashImage.SetActive(true);
            }
        }
    }

    //public void AddFlashlight()
    //{
    //    flashlight.SetActive(true);
    //}

}
