using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLifetime : MonoBehaviour {

    public float Lifetime = 0.5f;
    public float currentLife;

	// Update is called once per frame
	void Update () {
        currentLife += Time.deltaTime;
        if (currentLife >= Lifetime)
        {
            Destroy(gameObject);
        }
	}
}
