using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerButton : MonoBehaviour
{
    public bool CurrentIn = false;
    public float Timer;
    public float WaitTime = 1;

    private void Update()
    {
        Timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RHand")
        {
            CurrentIn = true;
        }
        if(other.gameObject.tag == "LHand")
        {
            CurrentIn = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Timer >= WaitTime)
        {
            if (other.gameObject.tag == "RHand")
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f)
                {
                    if (gameObject.GetComponent<SelectActive>() != null)
                    {
                        gameObject.GetComponent<SelectActive>().Pressed();
                        CurrentIn = false;
                        Timer = 0;
                    }
                    if (gameObject.GetComponent<ActiveWeaponSlot>() != null)
                    {
                        gameObject.GetComponent<ActiveWeaponSlot>().Activated();
                        CurrentIn = false;
                        Timer = 0;
                    }
                }
            }
            if (other.gameObject.tag == "LHand")
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f)
                {
                    if (gameObject.GetComponent<SelectActive>() != null)
                    {
                        gameObject.GetComponent<SelectActive>().Pressed();
                        CurrentIn = false;
                        Timer = 0;
                    }
                    if (gameObject.GetComponent<ActiveWeaponSlot>() != null)
                    {
                        gameObject.GetComponent<ActiveWeaponSlot>().Activated();
                        CurrentIn = false;
                        Timer = 0;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RHand")
        {
            CurrentIn = false;
        }
        if (other.gameObject.tag == "LHand")
        {
            CurrentIn = false;
        }
    }
}
