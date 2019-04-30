using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WepCollision : MonoBehaviour {

    public Transform weapontip;
    public GameObject Hit;
    public GameObject CurrentHit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            CurrentHit = Instantiate(Hit, weapontip.position, weapontip.rotation, weapontip);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        CurrentHit.GetComponent<HitLifetime>().currentLife = 0;
    }
    private void OnTriggerExit(Collider other)
    {
        CurrentHit.GetComponentInChildren<ParticleSystem>().enableEmission = false;
    }
}
