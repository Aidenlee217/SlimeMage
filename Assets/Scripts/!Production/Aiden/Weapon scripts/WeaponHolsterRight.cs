using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolsterRight : MonoBehaviour {

    public GameObject RH;
    public GameObject WepManager;
    public GameObject rhand;
    public GameObject FloatPos;
    public bool Onfloatpos = false;
    public float Speed = 1;

    public float Respawntime = 5;
    public float Timer;

    public GameObject HolsteredWeapon;
    public GameObject ActiveWeapon;

    public bool Active = false;
    public bool CurrentIn = false;
    public bool Run = false;

    // Use this for initialization
    void Start()
    {
        RH = GameObject.FindGameObjectWithTag("RHand");
    }

    // Update is called once per frame
    void Update()
    {
        if (Active == true)
        {
            if (Onfloatpos == true)
            {
                ActiveWeapon.transform.position = Vector3.MoveTowards(ActiveWeapon.transform.position, FloatPos.transform.position, Speed * Time.deltaTime);
                ActiveWeapon.transform.rotation = FloatPos.transform.rotation;
            }
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true)
            {
                if (Onfloatpos == false)
                {
                    ActiveWeapon.transform.position = RH.transform.position;
                    ActiveWeapon.transform.rotation = RH.transform.rotation;
                }
                else
                {
                    if (CurrentIn == true)
                    {
                        Timer += Time.deltaTime;
                        if (Timer >= Respawntime)
                        {
                            rhand.SetActive(true);
                            ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
                            ActiveWeapon.transform.position = new Vector3(0, 0, 0);
                            HolsteredWeapon.SetActive(true);
                            RH.GetComponent<OVRGrabber>().enabled = true;
                            Active = false;
                            Run = true;
                            Onfloatpos = false;
                        }
                    }
                }
            }
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == false)
            {
                Timer = 0;
                if (Onfloatpos == false)
                {
                    if (Run == false)
                    {
                        if (CurrentIn == true)
                        {
                            rhand.SetActive(true);
                            ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
                            ActiveWeapon.transform.position = new Vector3(0, 0, 0);
                            HolsteredWeapon.SetActive(true);
                            RH.GetComponent<OVRGrabber>().enabled = true;
                            Active = false;
                            Run = true;
                        }
                        else if (ActiveWeapon.tag == "Book")
                        {
                            rhand.SetActive(true);
                            RH.GetComponent<OVRGrabber>().enabled = true;
                            FloatPos.transform.position = ActiveWeapon.transform.position;
                            FloatPos.transform.rotation = ActiveWeapon.transform.rotation;
                            Onfloatpos = true;
                        }
                        else
                        {
                            StartCoroutine(Reset());
                            //LH.GetComponent<OVRGrabber>().enabled = true;
                            //Destroy(ActiveWeapon);
                            //HolsteredWeapon.SetActive(true);
                            //Active = false;
                            //Run = true;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RHand")
        {
            CurrentIn = true;
            RH.GetComponent<OVRGrabber>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RHand")
        {
            if (HolsteredWeapon.activeSelf == true)
            {
                if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) == true)
                {
                    ActiveWeapon.transform.position = RH.transform.position;
                    HolsteredWeapon.SetActive(false);
                    rhand.SetActive(false);
                    Active = true;
                    Run = false;
                    CurrentIn = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RHand")
        {
            CurrentIn = false;
            if(Active == false)
            {
                RH.GetComponent<OVRGrabber>().enabled = true;
            }
        }
    }

    IEnumerator Reset()
    {
        rhand.SetActive(true);
        //ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
        RH.GetComponent<OVRGrabber>().enabled = true;
        Active = false;
        ActiveWeapon.transform.position = new Vector3(0, -10, 0);
        yield return new WaitForSeconds(Respawntime);
        HolsteredWeapon.SetActive(true);
        Run = true;
        yield return true;
    }
}
