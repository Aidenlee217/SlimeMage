using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTPCamera : MonoBehaviour
{
    private const float yAngleMin = -50;
    private const float yAngleMax = 50;

    public Transform lookAt;
    public Transform camTransform;

    public TestPlayerScript player;

    private Camera cam;

    public float multi;

    public float distance = 2.5f;
    private float currentX = 0;
    private float currentY = 0;
    private float sensitivityX = 4;
    private float sensitivityY = 1;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        player = GameObject.FindObjectOfType<TestPlayerScript>();
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);   

        if(player.isAiming == true)
        {
            if (Input.GetButton("Fire2"))
            {
                if (distance > 1)
                {
                    distance -= multi * Time.deltaTime;
                }
            }
            else
            {
                if (distance < 2.5)
                {
                    distance += multi * Time.deltaTime;
                }
            }
        }
        else
        {
            if (distance < 2.5)
            {
                distance += multi * Time.deltaTime;
            }
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
