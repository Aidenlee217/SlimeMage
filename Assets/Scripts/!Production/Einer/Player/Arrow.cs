using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody myBody;
    private float lifeTimer = 2f;
    private float timer;
    private bool hitsomething = false;
    public Collider myCollider;

    public TestPlayerScript player;
    public Collider playerCollider;

    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(myBody.velocity);
        myCollider = GetComponent<BoxCollider>();
        player = GameObject.FindObjectOfType<TestPlayerScript>();
        playerCollider = player.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if(!hitsomething)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitsomething = true;
        this.transform.parent = collision.gameObject.transform;
        myCollider.enabled = false;
        Stick();
    }

    void Stick()
    {
        myBody.isKinematic = true;
    }
}
