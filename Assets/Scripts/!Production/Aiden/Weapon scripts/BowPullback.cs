using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPullback : MonoBehaviour {

    public Transform Opos;

    public GameObject target;
    public GameObject arrow;
    public GameObject activearrow;
    public GameObject Strungarrow;

    public GameObject RH;
    public GameObject LH;

    public Vector3 rot;

    public bool R;
    public bool L;

    public bool launch = false;

    public float distance;

    public bool active = false;

	// Use this for initialization
	void Start () {
        RH = GameObject.FindGameObjectWithTag("RHand");
        LH = GameObject.FindGameObjectWithTag("LHand");
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(gameObject.transform.position, Opos.transform.position);
        if (active == true)
        {
            //if (L == true)
            //{
            //    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) <= 0.5f)
            //    {
            //        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == false)
            //        {
            //            if (launch == true)
            //            {
            //                activearrow = Instantiate(arrow, target.transform.position, Strungarrow.transform.rotation);
            //                Strungarrow.SetActive(false);
            //                gameObject.transform.position = Opos.transform.position;
            //                activearrow.GetComponent<ArrowLaunch>().multiplyer = distance;
            //                activearrow.GetComponent<ArrowLaunch>().Launch();
            //                launch = false;
            //            }
            //            active = false;
            //        }
            //    }

            //    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f)
            //    {
            //        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == true)
            //        {
            //            gameObject.transform.position = LH.transform.position;
            //            Strungarrow.transform.LookAt(target.transform);
            //        }
            //    }
            //}
            if (R == true)
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.5f)
                {
                    if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == false)
                    {
                        if (launch == true)
                        {
                            activearrow = Instantiate(arrow, target.transform.position, Strungarrow.transform.rotation);
                            Strungarrow.SetActive(false);
                            gameObject.transform.position = Opos.transform.position;
                            activearrow.GetComponent<ArrowLaunch>().multiplyer = distance;
                            //activearrow.GetComponent<ArrowLaunch>().Launch();
                            launch = false;
                            active = false;
                        }
                    }
                }

                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f)
                {
                    if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == true)
                    {
                        gameObject.transform.position = RH.transform.position;
                        Strungarrow.transform.position = RH.transform.position;
                        Strungarrow.transform.LookAt(target.transform);
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "LHand")
        //{
        //    if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= 0.5f)
        //    {
        //        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbRest) == true)
        //        {
        //            L = true;
        //            if (active == false)
        //            {
        //                Strungarrow.SetActive(true);
        //                launch = true;
        //                active = true;
        //            }

        //        }
        //    }
        //}
        if (other.gameObject.tag == "RHand")
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0.5f)
            {
                if (OVRInput.Get(OVRInput.Touch.SecondaryThumbRest) == true)
                {
                    R = true;
                    if (active == false)
                    {
                        Strungarrow.SetActive(true);
                        launch = true;
                        active = true;
                    }
                    
                }
            }
        }
    }
}
