using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public new string name = "New item";
    public string description = "New description";
    public Sprite icon;
    public int currentQuantity = 1;
    public int maxQuantity = 16;

    public int equippableItemIndex = -1;

    [Header("Item Use")]
    public UnityEvent myEvent;
    public bool removeOneOnUse;

    public void UseItem() 
    { 
        if (myEvent.GetPersistentEventCount() > 0) 
        { 
            myEvent.Invoke();

            if (removeOneOnUse)
            {
                currentQuantity--;
            }
        }
    }
}
