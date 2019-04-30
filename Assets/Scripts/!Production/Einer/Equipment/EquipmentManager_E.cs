using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager_E : MonoBehaviour
{
    #region Singlton

    public static EquipmentManager_E Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public Equipment_E[] currentEquipment;
    public Image[] EquipmentSlots;
    public GameObject rightArmSlot;

    Inventory_E inventory;

    private void Start()
    {
        inventory = Inventory_E.instance;

        rightArmSlot = GameObject.Find("Right Arm Slot");

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        currentEquipment = new Equipment_E[numSlots];
    }

    public void Equip(Equipment_E newItem)
    {
        int slotIndex = (int)newItem.EquipSlot;

        Equipment_E olditem = null;

        if (currentEquipment[slotIndex] != null)
        {
            olditem = currentEquipment[slotIndex];
            olditem.Remove();
            inventory.Add(olditem);
        }

        currentEquipment[slotIndex] = newItem;

    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment_E olditem = currentEquipment[slotIndex];
            inventory.Add(olditem);

            currentEquipment[slotIndex] = null;
        }
    }

    public void UnequipRightArm()
    {
        foreach (Transform child in rightArmSlot.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
            foreach (Transform child in rightArmSlot.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

}
