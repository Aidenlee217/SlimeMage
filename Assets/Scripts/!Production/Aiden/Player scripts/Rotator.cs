using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotator : MonoBehaviour {


    public Vector3 Speed;
    //public float Y;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Y = gameObject.transform.eulerAngles.y;
        //gameObject.transform.localEulerAngles = new Vector3(0, Y + (Speed * Time.deltaTime), 0);
        transform.Rotate(Speed * Time.deltaTime);
	}
}
