using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHBLook : MonoBehaviour {

    public GameObject PlayerCam;

	// Use this for initialization
	void Start () {
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(PlayerCam.transform);
	}
}
