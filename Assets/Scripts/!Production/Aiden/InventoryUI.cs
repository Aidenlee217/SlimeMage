using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform Parent;

    VRInventory inventory;

    VRInventorySlot[] slots;
    
	// Use this for initialization
	void Start () {
        inventory = VRInventory.instance;
        //inventory.onItemChangedCallback += UpdateUI;

        slots = Parent.GetComponentsInChildren<VRInventorySlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        for(int i = 0; i<slots.Length; ++i)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
