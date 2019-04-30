using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolsterLeft : MonoBehaviour{

    public GameObject LH;
    public GameObject WepManager;
    public GameObject lhand;
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
        LH = GameObject.FindGameObjectWithTag("LHand");
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
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true)
            {
                if (Onfloatpos == false)
                {
                    ActiveWeapon.transform.position = LH.transform.position;
                    ActiveWeapon.transform.rotation = LH.transform.rotation;
                }
                else
                {
                    if (CurrentIn == true)
                    {
                        Timer += Time.deltaTime;
                        if (Timer >= Respawntime)
                        {
                            lhand.SetActive(true);
                            ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
                            ActiveWeapon.transform.position = new Vector3(0, 0, 0);
                            HolsteredWeapon.SetActive(true);
                            LH.GetComponent<OVRGrabber>().enabled = true;
                            Active = false;
                            Run = true;
                            Onfloatpos = false;
                        }
                    }
                }
            }
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == false)
            {
                Timer = 0;
                if (Onfloatpos == false)
                {
                    if (Run == false)
                    {
                        if (CurrentIn == true)
                        {
                            lhand.SetActive(true);
                            ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
                            ActiveWeapon.transform.position = new Vector3(0, 0, 0);
                            HolsteredWeapon.SetActive(true);
                            LH.GetComponent<OVRGrabber>().enabled = true;
                            Active = false;
                            Run = true;
                        }
                        else if (ActiveWeapon.tag == "Book")
                        {
                            lhand.SetActive(true);
                            LH.GetComponent<OVRGrabber>().enabled = true;
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
        if (other.gameObject.tag == "LHand")
        {
            CurrentIn = true;
            LH.GetComponent<OVRGrabber>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LHand")
        {
            if (HolsteredWeapon.activeSelf == true)
            {
                if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) == true)
                {
                    ActiveWeapon.transform.position = LH.transform.position;
                    HolsteredWeapon.SetActive(false);
                    lhand.SetActive(false);
                    Active = true;
                    Run = false;
                    CurrentIn = false;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LHand")
        {
            CurrentIn = false;
            if (Active == false)
            {
                LH.GetComponent<OVRGrabber>().enabled = true;
            }
        }
    }

    IEnumerator Reset()
    {
        lhand.SetActive(true);
        //ActiveWeapon.GetComponent<Rigidbody>().isKinematic = false;
        LH.GetComponent<OVRGrabber>().enabled = true;
        Active = false;
        ActiveWeapon.transform.position = new Vector3(0, -10, 0);
        yield return new WaitForSeconds(Respawntime);
        HolsteredWeapon.SetActive(true);
        Run = true;
        yield return true;
    }
}
