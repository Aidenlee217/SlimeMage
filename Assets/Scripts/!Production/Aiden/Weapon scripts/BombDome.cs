using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDome : MonoBehaviour {

    public float timer;
    public float shrinktime;
    public float lifetime;
    public float multi;

    public float rate;

    public GameObject Dome1;
    public GameObject Dome2;

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
		if(timer <= 0.25)
        {
            Dome1.transform.localScale += new Vector3(rate * Time.deltaTime, rate * Time.deltaTime, rate * Time.deltaTime);
            Dome2.transform.localScale += new Vector3(rate * Time.deltaTime, rate * Time.deltaTime, rate * Time.deltaTime);
        }
        if(timer >= shrinktime)
        {
            if (Dome1.transform.localScale.x >= 0)
            {
                Dome1.transform.localScale -= new Vector3(rate / lifetime / multi * Time.deltaTime, rate / lifetime / multi * Time.deltaTime, rate / lifetime / multi * Time.deltaTime);
            }
            if (Dome2.transform.localScale.x >= 0)
            {
                Dome2.transform.localScale -= new Vector3(rate / lifetime / multi * Time.deltaTime, rate / lifetime / multi * Time.deltaTime, rate / lifetime / multi * Time.deltaTime);
            }
        }
	}
}
