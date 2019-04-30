using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour {

    public GameObject inventory;

    public bool isLocked = true;
    public bool isVisible = true;

    // Update is called once per frame
    void Update ()
    {
        if(isLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
	}
}
