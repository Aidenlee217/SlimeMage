using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

    public float speed;
    public float lifetime;
    public float maxlife;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifetime += Time.deltaTime;
        gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        if(lifetime >= maxlife)
        {
            Destroy(gameObject);
        }
	}
}
