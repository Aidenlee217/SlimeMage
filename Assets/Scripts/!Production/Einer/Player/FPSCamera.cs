using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour {

    public enum Rotation_Axes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public Rotation_Axes axes = Rotation_Axes.MouseXAndY;

    public float speed = 2f;
    public float sensitivity = 2f;
    CharacterController player;

    public GameObject eyes;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;

    public float minimumY = -60F;
    public float maximumY = 60F;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(axes == Rotation_Axes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);

            moveFB = Input.GetAxis("Vertical") * speed;
            moveLR = Input.GetAxis("Horizontal") * speed;

            Vector3 movement = new Vector3(moveLR, 0, moveFB);
            transform.Rotate(0, rotX, 0);
            eyes.transform.Rotate(-rotY, 0, 0);

            movement = transform.rotation * movement;
            player.Move(movement * Time.deltaTime);
        }
        else
        {
            rotY += Input.GetAxis("Mouse Y") * sensitivity;
            rotY = Mathf.Clamp(rotY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotY, transform.localEulerAngles.y, 0);
        }


       
    }
}
