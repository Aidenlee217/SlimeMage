using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item_E")]
public class Item_E : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject PhysicalItem;
    public bool isDefaultItem = false;
    public bool Stackable = false;
    public int StackAmmount = 1;

    public TestPlayerScript player;

    public GameObject instantiatedItem;

    public Equipment_E equipment;
    public GameObject RightArmSlot;

    public virtual void Use()
    {
        player = GameObject.FindObjectOfType<TestPlayerScript>();
        RightArmSlot = GameObject.Find("Right Arm Slot");


        // Use the item
        if (equipment.EquipSlot == EquipmentSlots.Weapon)
        {
            instantiatedItem = Instantiate(PhysicalItem, RightArmSlot.transform.position, RightArmSlot.transform.rotation) as GameObject;
            player.meleeStance = true;
            player.weapon = instantiatedItem;
            instantiatedItem.gameObject.tag = "Equipped";
            instantiatedItem.transform.SetParent(RightArmSlot.transform);
        }
        // Something happens

        Debug.Log("using" + name);
    }

    public virtual void RemoveFromHand()
    {
        Destroy(instantiatedItem);
    }

    public void RemoveFromInventory()
    {
        Inventory_E.instance.Remove(this);
    }
}

