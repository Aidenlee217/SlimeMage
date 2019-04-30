using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public Camera FPCamera;

    public Camera TPCamera;

    public bool ThirdPersonView = true;

    private FPSCamera FPCScript;
    
    // Use this for initialization
	void Start ()
    {
        //FPCamera.GetComponent<Camera>().enabled = false;
        //TPCamera.GetComponent<Camera>().enabled = true;

        FPCScript = GetComponent<FPSCamera>();
        ThirdPersonView = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown("r"))
        {
            ThirdPersonView = !ThirdPersonView;
        }

        if(ThirdPersonView == true)
        {
            //FPCamera.GetComponent<Camera>().enabled = false;
            //TPCamera.GetComponent<Camera>().enabled = true;
            FPCamera.gameObject.SetActive(false);
            FPCScript.enabled = false;
            TPCamera.gameObject.SetActive(true);
        }

        if (ThirdPersonView == false)
        {
            //FPCamera.GetComponent<Camera>().enabled = true;
            //TPCamera.GetComponent<Camera>().enabled = false;
            FPCamera.gameObject.SetActive(true);
            FPCScript.enabled = true;
            TPCamera.gameObject.SetActive(false);
        }
    }
}
