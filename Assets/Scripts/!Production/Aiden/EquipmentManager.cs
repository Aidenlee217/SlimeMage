using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    #region Singlton

    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public GameObject Armorslots;
    public VRArmorSlot[] equipmentslots;

    VRInventory inventory;

    private void Start()
    {
        inventory = VRInventory.instance;

        equipmentslots = Armorslots.GetComponentsInChildren<VRArmorSlot>();

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.EquipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;

        equipmentslots[slotIndex].AddItem(newItem);
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex]!= null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            equipmentslots[slotIndex].ClearSlot();
        }
    }

    public void UnequipAll()
    {
        for(int i = 0; i<currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

}
