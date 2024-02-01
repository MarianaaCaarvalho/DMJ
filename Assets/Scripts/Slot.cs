using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;
    private Item heldItem;

    private Color opaque = new Color(1,1,1,1);
    private Color transparent = new Color(1, 1, 1, 0);

    private Image thisSlotImage;

    public TMP_Text thisSlotQuantityText;

    public void InitialiseSlot() 
    { 
        thisSlotImage = gameObject.GetComponent<Image>();
        thisSlotQuantityText = transform.GetChild(0).GetComponent<TMP_Text>();
        thisSlotImage.sprite = null;
        thisSlotImage.color = transparent;
        SetItem(null);
    }

    public void SetItem(Item item)
    {
        heldItem = item;

        if (item != null)
        {
            thisSlotImage.sprite = heldItem.icon;
            thisSlotImage.color = opaque;
            updateData();
        }
        else
        {
            thisSlotImage.sprite = null;
            thisSlotImage.color = transparent;
            updateData();
        }
    }

    public Item GetItem()
    {
        return heldItem;
    }

    public void updateData()
    {
        if (heldItem != null) 
        {
            thisSlotQuantityText.text = heldItem.currentQuantity.ToString();
        }
        else 
        {
            thisSlotQuantityText.text = "";
        }   
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        hovered = false;
    }
}
