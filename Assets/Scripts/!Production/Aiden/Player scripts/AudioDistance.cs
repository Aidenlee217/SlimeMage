using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistance : MonoBehaviour
{
    public bool active = false;
    public bool Calm = true;

    public float radius;

    public GameObject[] activeenemy;

    private void Start()
    {
        radius = gameObject.transform.localScale.x;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Calm = false;
            for(int i = 0; i < activeenemy.Length; ++i)
            {
                activeenemy[i] = other.gameObject;
            }
        }
    }

    public void Check()
    {
        active = false;
        for (int i = 0; i < activeenemy.Length; ++i)
        {
            if (activeenemy[i] != null)
            {
                if (Vector3.Distance(gameObject.transform.position, activeenemy[i].transform.position) <= radius)
                {
                    active = true;
                }
            }
            else
            {

            }
        }
        if(active == true)
        {
            Calm = false;
        }
        else
        {
            Calm = true;
        }
    }
}
