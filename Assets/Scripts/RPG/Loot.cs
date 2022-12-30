using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Interactable
{
    [SerializeField]
    private Item item;

    public override void OnInteract(GameObject player)
    {
        base.OnInteract(player);
        var inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Add(item);
            Destroy(gameObject);
        }
    }

    void PickUp ()
    {

    }
}
