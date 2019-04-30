using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveGearSlot : MonoBehaviour
{
    public string slottype;

    public GameObject InventoryHolder;
    public GameObject TempSaveSlot;
    public GameObject CurrentActiveSlot;

    public Text Text;
    public string EmptyCustomText;

    public GameObject GearOriginPoint;

    public GameObject Emptyplaceholder;

    public GameObject TempGear;

    public GameObject OldGear;

    public GameObject CurrentActiveGear;

    public GameObject ActiveGear;
    public Image Weapon;

    public void Activated()
    {
        if (InventoryHolder.GetComponent<ActiveSlots>().CurrentActiveSlot != null)
        {
            CurrentActiveSlot = InventoryHolder.GetComponent<ActiveSlots>().CurrentActiveSlot;
            if (CurrentActiveSlot != TempSaveSlot)
            {
                if (CurrentActiveSlot.GetComponent<SlotInventory>().SlotType == slottype)
                {
                    TempSaveSlot = CurrentActiveSlot;
                    Updated();
                }
            }
        }
        else
        {
            CurrentActiveSlot = null;
            TempSaveSlot = null;
            Updated();
        }
    }

    public void Updated()
    {
        if (TempSaveSlot != null)
        {
            Text.text = TempSaveSlot.GetComponentInChildren<Text>().text;
            ActiveGear = CurrentActiveSlot.GetComponent<SlotInventory>().HolsteredWeapon;
            ChangeWeapons();
        }
        else
        {
            Text.text = EmptyCustomText;
            LoseWeapons();
        }
    }

    public void ChangeWeapons()
    {
        OldGear = CurrentActiveGear;
        TempGear = Instantiate(ActiveGear, GearOriginPoint.transform.position, Quaternion.identity, GearOriginPoint.transform);
        CurrentActiveGear = TempGear;
        Destroy(OldGear);
    }

    public void LoseWeapons()
    {
        OldGear = CurrentActiveGear;
        TempGear = Instantiate(Emptyplaceholder, GearOriginPoint.transform.position, Quaternion.identity, GearOriginPoint.transform);
        CurrentActiveGear = TempGear;
        Destroy(OldGear);
    }
}
