using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject PhysicalItem;
    public bool isDefaultItem = false;
    public bool Stackable = false;
    public int StackAmmount = 1;

    public virtual void Use()
    {
        // Use the item
        // Something happens

        Debug.Log("using" + name);
    }

    public void RemoveFromInventory()
    {
        VRInventory.instance.Remove(this);
    }
}
