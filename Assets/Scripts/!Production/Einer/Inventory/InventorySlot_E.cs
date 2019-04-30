using UnityEngine;
using UnityEngine.UI;

public class InventorySlot_E : MonoBehaviour {

    public Image icon;
    public Button removeButton;

    Item_E item;

    public void AddItem (Item_E newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot ()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory_E.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item !=null)
        {
            item.Use();
        }
    }
}
