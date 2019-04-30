using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActiveTab : MonoBehaviour
{
    public GameObject[] Tabs;
    public GameObject ActiveTab;

    public void Run()
    {
        for(int i=0;i<Tabs.Length; i++)
        {
            if(Tabs[i].activeSelf == true)
            {
                ActiveTab = Tabs[i];
            }
        }
    }
}
