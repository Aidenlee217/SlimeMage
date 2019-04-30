using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInventory : MonoBehaviour
{
    public string[] Types = new[] { "Weapon", "Head", "Chest", "Legs", "Resources", "Quest" };
    public string SlotType;

    public GameObject ActiveWeapon;
    public GameObject HolsteredWeapon;
    public GameObject GearPlacement;
    public GameObject SpawnableItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
