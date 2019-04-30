using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltRotator : MonoBehaviour {

    public GameObject PlayerCam;
    public float Y;
    public Vector3 pos;
    public float BeltDrop = 1;

	// Use this for initialization
	void Start () {
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
	}
	
	// Update is called once per frame
	void Update () {
        Y = PlayerCam.transform.eulerAngles.y;
        gameObject.transform.localEulerAngles = new Vector3(0, Y, 0);
        pos = PlayerCam.transform.position;
        pos = new Vector3(pos.x, pos.y - BeltDrop, pos.z);
        gameObject.transform.position = pos;
	}
}
