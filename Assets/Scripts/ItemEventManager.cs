using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemEventManager : MonoBehaviour
{
    private static ItemEventManager instance;

    [SerializeField] private List<ItemReference> itemReferences = new List<ItemReference>();

    public UnityEvent GetItemEvents(Item item)
    {
        ItemReference itemRef = itemReferences.Find(x => x.item.name == item.name);
        return itemRef != null ? itemRef.itemEvents : null;
    }

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
