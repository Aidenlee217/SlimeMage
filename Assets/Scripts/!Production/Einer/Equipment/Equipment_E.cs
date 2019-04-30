using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment_E")]
public class Equipment_E : Item_E
{
    public EquipmentSlots EquipSlot;

    public int Armormodifier;
    public int DamageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager_E.Instance.Equip(this);
        RemoveFromInventory();
    }

    public void Remove()
    {
        base.RemoveFromHand();
    }

}

public enum EquipmentSlots { Head, Chest, Legs, Weapon, Shield }