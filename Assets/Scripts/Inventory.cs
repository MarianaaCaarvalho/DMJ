using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("UI")]
    public GameObject inventory;
    public List<Slot> inventorySlots = new List<Slot>();
    public Image crosshair;
    public TMP_Text itemHoverText;

    [Header("Raycast")]
    public float raycastDistance = 5f;
    public LayerMask itemLayer;

    public void Start()
    {
        toggleInventory(false);

        foreach (Slot uiSlot in inventorySlots) 
        {
            uiSlot.InitialiseSlot();
        }
    }

    public void Update()
    {
        itemRaycast(Input.GetKeyDown(KeyCode.E));

        if (Input.GetKeyDown(KeyCode.I))
        {
            toggleInventory(!inventory.activeInHierarchy);
        }  
    }

    private void itemRaycast(bool hasClicked = false) 
    {
        itemHoverText.text = "";
        Ray ray = Camera.main.ScreenPointToRay(crosshair.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, itemLayer))
        {
            if (hit.collider != null)
            {
                if (hasClicked)
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    if (newItem) 
                    {
                        AddItemToInventory(newItem);
                    }
                }
                else
                {
                    Item newItem = hit.collider.GetComponent<Item>();
                    if (newItem)
                    {
                        itemHoverText.text = newItem.name;
                    }
                }
            }
        }
    }

    private void AddItemToInventory(Item itemToAdd) 
    {
        int leftoverQuantity = itemToAdd.currentQuantity;
        Slot openSlot = null;
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Item heldItem = inventorySlots[i].GetItem();

            if (heldItem != null && itemToAdd.name == heldItem.name)
            {
                int freeSpaceInSlot = heldItem.maxQuantity - heldItem.currentQuantity;

                if (freeSpaceInSlot >= leftoverQuantity)
                {
                    heldItem.currentQuantity += leftoverQuantity;
                    Destroy(itemToAdd.gameObject);
                    inventorySlots[i].updateData();
                    return;
                }
                else // Add as much as we can to the current slot
                {
                    heldItem.currentQuantity = heldItem.maxQuantity;
                    leftoverQuantity -= freeSpaceInSlot;
                }
            }
            else if (heldItem == null)
            {
                if (!openSlot)
                    openSlot = inventorySlots[i];
            }

            inventorySlots[i].updateData();
        }

        if (leftoverQuantity > 0 && openSlot)
        {
            openSlot.SetItem(itemToAdd);
            itemToAdd.currentQuantity = leftoverQuantity;
            itemToAdd.gameObject.SetActive(false);
        }
        else
        {
            itemToAdd.currentQuantity = leftoverQuantity;
        }
    }

    private void toggleInventory(bool enable)
    {
        inventory.SetActive(enable);

        Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;

        // Disable the rotation of the camera.
        Camera.main.GetComponent<FirstPersonLook>().sensitivity = enable ? 0 : 2;
    }
}
