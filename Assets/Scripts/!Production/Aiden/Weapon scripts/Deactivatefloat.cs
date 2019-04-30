using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivatefloat : MonoBehaviour {

    public WeaponHolsterLeft WHL;
    public WeaponHolsterRight WHR;

    public bool LHtrue;
    public bool RHtrue;

    private void Update()
    {
        if (LHtrue == true)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true)
            {
                WHL.Onfloatpos = false;
            }
        }
        if (RHtrue == true)
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true)
            {
                WHR.Onfloatpos = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (WHL.Onfloatpos == true)
        {
            LHtrue = true;
        }
        if (WHR.Onfloatpos == true)
        {
            RHtrue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (WHL.Onfloatpos == true)
        {
            LHtrue = false;
        }
        if (WHR.Onfloatpos == true)
        {
            RHtrue = false;
        }
    }
}
