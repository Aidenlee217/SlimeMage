using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_E : MonoBehaviour
{

    public float radius = 3f;

    Transform playerTransform;

    public Transform interactionTransform;

    bool hasInteracted = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + playerTransform.name);
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= radius)
        {
            //Reminder
            //Activate interactable UI
            //Reminder
            Interact();
            hasInteracted = true;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}