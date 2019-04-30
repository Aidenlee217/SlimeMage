using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUIInteraction : MonoBehaviour {

    public bool armour = false;
    public bool inventory = true;

    private void OnTriggerStay(Collider other)
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
        {
            StartCoroutine(Interact());
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) == true)
        {
            StartCoroutine(Interact());
        }
    }

    IEnumerator Interact()
    {
        if(inventory == true)
        {
            if (gameObject.GetComponentInParent<VRInventorySlot>().item == false)
            {
                yield return false;
            }
            gameObject.GetComponentInParent<VRInventorySlot>().item.Use();
        }
        if(armour == true)
        {
            if(gameObject.GetComponentInParent<VRArmorSlot>().item == null)
            {
                yield return false;
            }
            gameObject.GetComponentInParent<VRArmorSlot>().item.Use();
        }
        yield return new WaitForSeconds(1);
        yield return true;
    }
}
