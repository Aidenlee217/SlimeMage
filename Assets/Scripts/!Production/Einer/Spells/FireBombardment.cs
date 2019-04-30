using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBombardment : MonoBehaviour
{

    public GameObject fireBombardment;
    public float magnitude = 10;
    public float speed;
    public TestPlayerScript playerScript;
    public Transform TPCamera;
    public Transform FPCamera;

    public Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<TestPlayerScript>();
        TPCamera = playerScript.TPCamera;
        FPCamera = playerScript.FPCamera;
        myCollider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.thirdPerson == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = TPCamera.transform.forward * 5;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = FPCamera.transform.forward * 5;
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(fireBombardment, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}