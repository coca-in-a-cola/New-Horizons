using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/RPG/Item")]
public class Item : ScriptableObject
{
    new public string name = "Item";
    public Sprite icon = null;

}
