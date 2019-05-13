using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyontrig : MonoBehaviour
{ 

    public GameObject GM;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("GM");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().Death();
        }
    }
}
