using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grimoire : MonoBehaviour {

    // Adjust the speed for the application.
    public float speed = 5.0f;
    public GameObject grimoireLocation;
    public Transform head;
    public Transform location;
    public float step;

    void Awake()
    {
        grimoireLocation = GameObject.Find("Grimoire Slot");
        head = GameObject.Find("FPCamera").transform;
        location = grimoireLocation.transform;
    }

    void Update()
    {
        // Move our position a step closer to the target.
        step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, location.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, location.position) < 0.001f)
        {
            //// Swap the position of the cylinder.
            //location.position *= -1.0f;
        }

        Vector3 targetDir = head.position - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
