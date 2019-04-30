using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelectInventory : MonoBehaviour
{
    public GameObject[] Inventory;

    public int slots;

    // Start is called before the first frame update
    void Start()
    {
        slots = Inventory.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        for(int i=0; i<slots; ++i)
        {
            if (Inventory[i].GetComponent<SelectActive>().active == true)
            {
                Inventory[i].GetComponent<SelectActive>().Reset();
            }
        }
    }
}
