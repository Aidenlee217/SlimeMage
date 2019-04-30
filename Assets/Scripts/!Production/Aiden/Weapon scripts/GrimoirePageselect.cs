using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimoirePageselect : MonoBehaviour
{

    public GameObject[] Pages;
    public GameObject SelectPage;

    public float timer;
    public float changetime;


    void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LHand")
        {
            if (timer >= changetime)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f)
                {
                    if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == true)
                    {
                        for (int i = 0; i < Pages.Length; ++i)
                        {
                            Pages[i].SetActive(false);
                        }
                        SelectPage.SetActive(true);
                        timer = 0;
                    }
                }
            }
        }
        if (other.gameObject.tag == "RHand")
        {
            if (timer >= changetime)
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f)
                {
                    if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == true)
                    {
                        for(int i = 0; i < Pages.Length; ++i)
                        {
                            Pages[i].SetActive(false);
                        }
                        SelectPage.SetActive(true);
                        timer = 0;
                    }
                }
            }
        }
    }

}
