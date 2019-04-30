using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public bool IN = false;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IN = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IN = false;
        }
    }
}
