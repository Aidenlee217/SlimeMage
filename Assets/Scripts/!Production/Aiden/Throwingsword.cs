using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwingsword : MonoBehaviour {

    public GameObject LH;
    public GameObject RH;
    public Vector3 velo;

	// Use this for initialization
	void Start () {
        LH = GameObject.FindGameObjectWithTag("LHand");
	}
	
	// Update is called once per frame
	void Update () {
        //velo = LH.GetComponent<Rigidbody>().velocity;
        if(gameObject.GetComponent<Rigidbody>().isKinematic == true)
        {
            velo = LH.GetComponent<Rigidbody>().velocity;
        }
        if (gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            gameObject.GetComponent<Rigidbody>().velocity = velo;
        }
	}
}
