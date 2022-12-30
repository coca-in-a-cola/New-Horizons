using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> items = new List<Item>();

    [SerializeField]
    private InventoryEventChannel OnItemChanged;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add (Item item)
    {
        items.Add(item);
        OnItemChanged.RaiseItemChanged(this);
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        OnItemChanged.RaiseItemChanged(this);
    }
}
