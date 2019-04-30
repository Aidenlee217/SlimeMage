using UnityEngine;

public class InventoryUI_E : MonoBehaviour {

    public Transform itemsParent;

    public GameObject inventoryUI;

    Inventory_E inventory;

    InventorySlot_E[] slots;

    LockCursor cursor;

    TestPlayerScript player;

    // Use this for initialization
	void Start ()
    {
        inventory = Inventory_E.instance;
        inventory.onItemChangedCallback += UpdateUI;

        cursor = GameObject.FindObjectOfType<LockCursor>();

        slots = itemsParent.GetComponentsInChildren<InventorySlot_E>();

        player = GameObject.FindObjectOfType<TestPlayerScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            cursor.isLocked = !cursor.isLocked;
            player.enabled = !player.enabled;
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

        }
	}

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
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
