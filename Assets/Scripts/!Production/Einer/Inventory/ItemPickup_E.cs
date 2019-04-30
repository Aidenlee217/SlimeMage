using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup_E : Interactable
{
    public GameObject self;

    public Item_E item_E;

    public float playerDistance;

    public GameObject playerCharacter;

    private void Start()
    {
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        self = gameObject;
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(playerCharacter.transform.position, transform.position);
    }

    private void OnMouseDown()
    {
        if (self.tag == "Pickup")
        {
            if (playerDistance <= radius)
            {
                Pickup();
            }
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
        Debug.Log("Picking up " + item_E.name);
        bool wasPickedUp = Inventory_E.instance.Add(item_E);
        if (wasPickedUp)
        {
            Destroy(self);
        }
    }
}