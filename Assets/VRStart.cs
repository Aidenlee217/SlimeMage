using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR.OpenVR;
using UnityEngine.XR;

public class VRStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (XRDevice.isPresent == true && string.IsNullOrEmpty(XRDevice.model))
        {
            Debug.Log("EMPTY VR DEVICE DETECTED!");
            //XRSettings.loadedDevice = XRDevice.Oculus;
            XRSettings.enabled = true;
            XRSettings.showDeviceView = true;
        }
    }
}
