using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNavigation : MonoBehaviour {

    public GameObject activeslot;
    public GameObject[] otherslots;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "RHand")
        {
            if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true)
            {
                activeslot.SetActive(true);
                for (int i = 0; i<otherslots.Length; ++i)
                {
                    otherslots[i].SetActive(false);
                }
            }
        }
        if (other.gameObject.tag == "LHand")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true)
            {
                activeslot.SetActive(true);
                for (int i = 0; i < otherslots.Length; ++i)
                {
                    otherslots[i].SetActive(false);
                }
            }
        }
    }
}
