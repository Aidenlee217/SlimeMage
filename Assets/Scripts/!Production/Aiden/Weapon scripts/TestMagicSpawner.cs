using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMagicSpawner : MonoBehaviour {

    public GameObject Testmagic;
    public GameObject RecentlySpawned;
    public float Waittime;
    public float timer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= Waittime)
        {
            if (Input.GetButtonDown("Jump"))
            {
                RecentlySpawned = Instantiate(Testmagic, gameObject.transform.position, Quaternion.identity);
                RecentlySpawned.transform.rotation = gameObject.transform.rotation;
                timer = 0;
            }
        }
    }
}
