using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera1 : MonoBehaviour {

	private const float Y_Angle_Min = -60.0f;
	private const float Y_Angle_Max = 60.0f;

	public Transform lookAt;
	public Transform camTransform;
    public Transform character;

	private Camera cam;

    private float moveFB, moveLR;
    public float moveSpeed = 2f;

    private float distance = 10.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;	
	
	// Use this for initialization
	void Start () 
	{
		camTransform = transform;
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentX += Input.GetAxis("Mouse X");
		currentY -= Input.GetAxis("Mouse Y");

		currentY = Mathf.Clamp(currentY, Y_Angle_Min, Y_Angle_Max);

        moveFB = Input.GetAxis("Vertical") * moveSpeed;
        moveLR = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        movement = character.rotation * movement;
    }

	private void LateUpdate()
	{
		Vector3 dir = new Vector3(0,0,-distance);
		Quaternion rotation = Quaternion.Euler(currentY,currentX,0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt(lookAt.position);
	}
}
