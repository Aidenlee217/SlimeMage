using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateSpell : MonoBehaviour
{

    public bool Leftactive = false;
    public bool Rightactive = false;

    public bool Deactivate = false;

    public Image spellimage;

    public GameObject[] OtherSpellsNoGrav;
    public GameObject[] OtherSpellsGrav;

    public GameObject righthand;
    public GameObject lefthand;

    public GameObject recentspellRight;
    public GameObject recentspellLeft;

    public GameObject CurrentactiveL;
    public GameObject CurrentactiveR;

    public GameObject HeldSpell;
    public GameObject Spell;

    public float cooldowntime = 5;
    public float timer;

    private void Start()
    {
        righthand = GameObject.FindGameObjectWithTag("RHand");
        lefthand = GameObject.FindGameObjectWithTag("LHand");
    }

    private void Update()
    {
        if (timer <= cooldowntime)
        {
            timer += Time.deltaTime;
        }
        if (Leftactive == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) <= 0.5f)
            {
                if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == false)
                {
                    recentspellLeft = Instantiate(Spell, CurrentactiveL.transform.position, CurrentactiveL.transform.rotation);
                    Destroy(CurrentactiveL);
                    Leftactive = false;
                    if (OtherSpellsNoGrav != null)
                    {
                        for (int i = 0; i < OtherSpellsNoGrav.Length; ++i)
                        {
                            OtherSpellsNoGrav[i].GetComponent<activateSpell>().Deactivate = false;
                        }
                    }
                    if (OtherSpellsGrav != null)
                    {
                        for (int i = 0; i < OtherSpellsGrav.Length; ++i)
                        {
                            OtherSpellsGrav[i].GetComponent<ActivatenontrackSpell>().Deactivate = false;
                        }
                    }
                }
            }
        }
        if (Rightactive == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.5f)
            {
                if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == false)
                {
                    recentspellRight = Instantiate(Spell, CurrentactiveR.transform.position, CurrentactiveR.transform.rotation);
                    Destroy(CurrentactiveR);
                    Rightactive = false;
                    if (OtherSpellsNoGrav != null)
                    {
                        for (int i = 0; i < OtherSpellsNoGrav.Length; ++i)
                        {
                            OtherSpellsNoGrav[i].GetComponent<activateSpell>().Deactivate = false;
                        }
                    }
                    if (OtherSpellsGrav != null)
                    {
                        for (int i = 0; i < OtherSpellsGrav.Length; ++i)
                        {
                            OtherSpellsGrav[i].GetComponent<ActivatenontrackSpell>().Deactivate = false;
                        }
                    }
                }
            }
        }
        spellimage.fillAmount = timer / cooldowntime;
        if (recentspellLeft != null)
        {
            recentspellLeft.transform.rotation = lefthand.transform.rotation;
        }
        if (recentspellRight != null)
        {
            recentspellRight.transform.rotation = righthand.transform.rotation;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Deactivate == false)
        {

            if (timer >= cooldowntime)
            {
                if (other.gameObject.tag == "LHand")
                {
                    if(Leftactive == false)
                    {
                        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f)
                        {
                            if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == true)
                            {
                                if (CurrentactiveL != null)
                                {
                                    Destroy(CurrentactiveL);
                                }
                                Leftactive = true;
                                CurrentactiveL = Instantiate(HeldSpell, other.gameObject.transform.position, other.gameObject.transform.rotation, other.gameObject.transform);
                                timer = 0;
                                if (OtherSpellsNoGrav != null)
                                {
                                    for (int i = 0; i < OtherSpellsNoGrav.Length; ++i)
                                    {
                                        OtherSpellsNoGrav[i].GetComponent<activateSpell>().Deactivate = true;
                                    }
                                }
                                if (OtherSpellsGrav != null)
                                {
                                    for (int i = 0; i < OtherSpellsGrav.Length; ++i)
                                    {
                                        OtherSpellsGrav[i].GetComponent<ActivatenontrackSpell>().Deactivate = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (other.gameObject.tag == "RHand")
                {
                    if (Rightactive == false)
                    {
                        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f)
                        {
                            if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == true)
                            {
                                if (CurrentactiveR != null)
                                {
                                    Destroy(CurrentactiveR);
                                }
                                Rightactive = true;
                                CurrentactiveR = Instantiate(HeldSpell, other.gameObject.transform.position, other.gameObject.transform.rotation, other.gameObject.transform);
                                timer = 0;
                                if (OtherSpellsNoGrav != null)
                                {
                                    for (int i = 0; i < OtherSpellsNoGrav.Length; ++i)
                                    {
                                        OtherSpellsNoGrav[i].GetComponent<activateSpell>().Deactivate = true;
                                    }
                                }
                                if (OtherSpellsGrav != null)
                                {
                                    for (int i = 0; i < OtherSpellsGrav.Length; ++i)
                                    {
                                        OtherSpellsGrav[i].GetComponent<ActivatenontrackSpell>().Deactivate = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
