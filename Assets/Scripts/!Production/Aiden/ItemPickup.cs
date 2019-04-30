using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public float playerDistance;

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Storage")
        {
            Pickup();
        }       
    }

    private void OnMouseDown()
    {
        if(playerDistance <= radius)
        {
            Pickup();
        }
    }



    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Physics.IgnoreCollision(self.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    //        Debug.Log("Collided with " + collision.gameObject.name);
    //    }
    //}

    public void Pickup()
    {
        Debug.Log("Picking up "+item.name);
        bool wasPickedUp = VRInventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
