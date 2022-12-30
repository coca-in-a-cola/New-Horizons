using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inventory Event Channel", menuName = "ScriptableObjects/Event Channels/Inventory")]
public class InventoryEventChannel : ScriptableObject
{
    public delegate void OnItemChangedCallback(Inventory inventory);
    public OnItemChangedCallback OnItemChanged;

    public void RaiseItemChanged(Inventory inventory)
    {
        OnItemChanged?.Invoke(inventory);
    }
}
