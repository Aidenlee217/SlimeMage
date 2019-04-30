using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    Transform player;

    bool hasInteracted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void Interact()
    {
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + player.name);
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance<= radius)
        {
            //Reminder
            //Activate interactable UI
            //Reminder
            hasInteracted = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
