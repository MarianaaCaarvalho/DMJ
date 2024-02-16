using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEventManager : MonoBehaviour
{
    private static ItemEventManager instance;

    [SerializeField] private List<ItemReference> itemReferences = new List<ItemReference>();

    // THE ONLY IMPORTANT FUNCTION UNLESS YOUR'E A NERD IS THE GetItemEvents!
    // The function you can call from your items start function to get the events stored on this central manager.

    // Type "myEvent = ItemEventManager.Instance.GetItemEvents(this);" within a void start function on your item script!
    // If your item has events you don't need to add them to the item anymore and can instead use this central script!

    public UnityEvent GetItemEvents(Item item)
    {
        ItemReference itemRef = itemReferences.Find(x => x.item.name == item.name);
        return itemRef != null ? itemRef.itemEvents : null;
    }

    // Creates an instance of this script allowing us to call it from our item scripts.
    public static ItemEventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemEventManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("ItemEventManager");
                    instance = obj.AddComponent<ItemEventManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Ensures only one instance of the ItemEventManager exists.

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

[System.Serializable]
public class ItemReference
{
    public Item item;
    public UnityEvent itemEvents;
}
