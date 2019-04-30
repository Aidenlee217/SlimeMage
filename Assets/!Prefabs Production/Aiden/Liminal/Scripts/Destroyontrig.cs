using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyontrig : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Collider>().enabled = false;
            other.gameObject.GetComponent<Enemy>().Death();
        }
    }
}
