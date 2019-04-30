using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircles : MonoBehaviour
{

    public float Health;

    public float Rate;
    public float timer;

    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (timer >= Rate)
            {
                other.gameObject.GetComponent<PlayerHealth>().Health += Health;
            }
        }
    }
}
