using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour {

    public GameObject LastAdded;

    public bool[] boolswords;
    public bool[] boolLswords;
    public bool[] boolgrimoires;
    public bool[] boolbowsarrows;
    public bool[] boolhelms;
    public bool[] boolchests;
    public bool[] boollegs;
    public bool[] boolshields;
    public bool[] boolresources;

    public int[] Swords;
    public int[] LSwords;
    public int[] Grimoires;
    public int[] BowsArrows;
    public int[] Helms;
    public int[] Chests;
    public int[] Legs;
    public int[] Shields;
    public int[] Resources;

    public GameObject[] swords;
    public GameObject[] Lswords;
    public GameObject[] grimoires;
    public GameObject[] bowsarrows;
    public GameObject[] helms;
    public GameObject[] chests;
    public GameObject[] legs;
    public GameObject[] shields;
    public GameObject[] resources;

    public Image[] sword;
    public Image[] Lsword;
    public Image[] grimoire;
    public Image[] bowsarrow;
    public Image[] helm;
    public Image[] chest;
    public Image[] leg;
    public Image[] shield;
    public Image[] resource;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Add()
    {
        for (int i = 0; i < swords.Length; ++i)
        {
            if (swords[i] == LastAdded)
            {
                Swords[i] += 1;
            }
        }
        for (int i = 0; i < Lswords.Length; ++i)
        {
            if (Lswords[i] == LastAdded)
            {
                LSwords[i] += 1;
            }
        }
        for (int i = 0; i < grimoires.Length; ++i)
        {
            if (grimoires[i] == LastAdded)
            {
                Grimoires[i] += 1;
            }
        }
        for (int i = 0; i < bowsarrows.Length; ++i)
        {
            if (bowsarrows[i] == LastAdded)
            {
                BowsArrows[i] +=1;
            }
        }
        for (int i = 0; i < helms.Length; ++i)
        {
            if (helms[i] == LastAdded)
            {
                Helms[i] += 1;
            }
        }
        for (int i = 0; i < chests.Length; ++i)
        {
            if (chests[i] == LastAdded)
            {
                Chests[i] += 1;
            }
        }
        for (int i = 0; i < legs.Length; ++i)
        {
            if (legs[i] == LastAdded)
            {
                Legs[i] += 1;
            }
        }
        for (int i = 0; i < shields.Length; ++i)
        {
            if (shields[i] == LastAdded)
            {
                Shields[i] += 1;
            }
        }
        for (int i = 0; i < resources.Length; ++i)
        {
            if (resources[i] == LastAdded)
            {
                Resources[i] += 1;
            }
        }
    }

    public void Run()
    {
        for(int i =0; i < Swords.Length; ++i)
        {
            if (Swords[i] >= 1)
            {
                boolswords[i] = true;
            }
        }
        for (int i = 0; i < LSwords.Length; ++i)
        {
            if (LSwords[i] >= 1)
            {
                boolLswords[i] = true;
            }
        }
        for (int i = 0; i < Grimoires.Length; ++i)
        {
            if (Grimoires[i] >= 1)
            {
                boolgrimoires[i] = true;
            }
        }
        for (int i = 0; i < BowsArrows.Length; ++i)
        {
            if (BowsArrows[i] >= 1)
            {
                boolbowsarrows[i] = true;
            }
        }
        for (int i = 0; i < Helms.Length; ++i)
        {
            if (Helms[i] >= 1)
            {
                boolhelms[i] = true;
            }
        }
        for (int i = 0; i < Chests.Length; ++i)
        {
            if (Chests[i] >= 1)
            {
                boolchests[i] = true;
            }
        }
        for (int i = 0; i < Legs.Length; ++i)
        {
            if (Legs[i] >= 1)
            {
                boollegs[i] = true;
            }
        }
        for (int i = 0; i < Shields.Length; ++i)
        {
            if (Shields[i] >= 1)
            {
                boolshields[i] = true;
            }
        }
        for (int i = 0; i < Resources.Length; ++i)
        {
            if (Resources[i] >= 1)
            {
                boolresources[i] = true;
            }
        }
    }

    public void FixUpdate()
    {

    }
}
