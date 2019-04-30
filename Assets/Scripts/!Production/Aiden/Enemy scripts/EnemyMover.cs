using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<NavMeshAgent>().destination = target.transform.position;
	}
}
