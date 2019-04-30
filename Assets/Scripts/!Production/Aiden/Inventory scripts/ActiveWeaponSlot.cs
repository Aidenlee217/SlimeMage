using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeaponSlot : MonoBehaviour
{
    public GameObject InventoryHolder;
    public GameObject TempSaveSlot;
    public GameObject CurrentActiveSlot;

    public Text Text;
    public string EmptyCustomText;

    public GameObject WeaponHolster;
    public GameObject WeaponSpawn;

    public GameObject Emptyplaceholder;

    public GameObject tempholster;
    public GameObject tempweapon;

    public GameObject Oldholster;
    public GameObject Oldweapon;

    public GameObject HolsteredWeapon;
    public GameObject ActiveWeapon;
    public Image Weapon;

    public void Activated()
    {
        if (InventoryHolder.GetComponent<ActiveSlots>().CurrentActiveSlot != null)
        {
            CurrentActiveSlot = InventoryHolder.GetComponent<ActiveSlots>().CurrentActiveSlot;
            if (CurrentActiveSlot != TempSaveSlot)
            {
                if (CurrentActiveSlot.GetComponent<SlotInventory>().SlotType == "Weapon")
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
            HolsteredWeapon = CurrentActiveSlot.GetComponent<SlotInventory>().HolsteredWeapon;
            ActiveWeapon = CurrentActiveSlot.GetComponent<SlotInventory>().ActiveWeapon;
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
        if (WeaponHolster.GetComponent<WeaponHolsterLeft>() != null)
        {
            Oldholster = WeaponHolster.GetComponent<WeaponHolsterLeft>().HolsteredWeapon;
            Oldweapon = WeaponHolster.GetComponent<WeaponHolsterLeft>().ActiveWeapon;
            tempholster = Instantiate(HolsteredWeapon, WeaponHolster.transform.position, Quaternion.identity, WeaponHolster.transform);
            tempweapon = Instantiate(ActiveWeapon, WeaponSpawn.transform);
            WeaponHolster.GetComponent<WeaponHolsterLeft>().HolsteredWeapon = tempholster;
            WeaponHolster.GetComponent<WeaponHolsterLeft>().ActiveWeapon = tempweapon;
            Destroy(Oldholster);
            Destroy(Oldweapon);
        }
        if (WeaponHolster.GetComponent<WeaponHolsterRight>() != null)
        {
            Oldholster = WeaponHolster.GetComponent<WeaponHolsterRight>().HolsteredWeapon;
            Oldweapon = WeaponHolster.GetComponent<WeaponHolsterRight>().ActiveWeapon;
            tempholster = Instantiate(HolsteredWeapon, WeaponHolster.transform.position, Quaternion.identity, WeaponHolster.transform);
            tempweapon = Instantiate(ActiveWeapon, WeaponSpawn.transform);
            WeaponHolster.GetComponent<WeaponHolsterRight>().HolsteredWeapon = tempholster;
            WeaponHolster.GetComponent<WeaponHolsterRight>().ActiveWeapon = tempweapon;
            Destroy(Oldholster);
            Destroy(Oldweapon);
        }
    }

    public void LoseWeapons()
    {
        if(WeaponHolster.GetComponent<WeaponHolsterLeft>() != null)
        {
            Oldholster = WeaponHolster.GetComponent<WeaponHolsterLeft>().HolsteredWeapon;
            Oldweapon = WeaponHolster.GetComponent<WeaponHolsterLeft>().ActiveWeapon;
            tempholster = Instantiate(Emptyplaceholder, WeaponHolster.transform.position, Quaternion.identity, WeaponHolster.transform);
            tempweapon = Instantiate(Emptyplaceholder, WeaponSpawn.transform);
            WeaponHolster.GetComponent<WeaponHolsterLeft>().HolsteredWeapon = tempholster;
            WeaponHolster.GetComponent<WeaponHolsterLeft>().ActiveWeapon = tempweapon;
            Destroy(Oldholster);
            Destroy(Oldweapon);
        }
        if(WeaponHolster.GetComponent<WeaponHolsterRight>() != null)
        {
            Oldholster = WeaponHolster.GetComponent<WeaponHolsterRight>().HolsteredWeapon;
            Oldweapon = WeaponHolster.GetComponent<WeaponHolsterRight>().ActiveWeapon;
            tempholster = Instantiate(Emptyplaceholder, WeaponHolster.transform.position, Quaternion.identity, WeaponHolster.transform);
            tempweapon = Instantiate(Emptyplaceholder, WeaponSpawn.transform);
            WeaponHolster.GetComponent<WeaponHolsterRight>().HolsteredWeapon = tempholster;
            WeaponHolster.GetComponent<WeaponHolsterRight>().ActiveWeapon = tempweapon;
            Destroy(Oldholster);
            Destroy(Oldweapon);
        }
    }
}
