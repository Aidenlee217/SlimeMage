using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {

    public float enemyHealth;
    public bool DSEffect = false;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        damage();

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        
	}

    public void damage()
    {
        if (DSEffect == true)
        {
            StartCoroutine(DarkShadowEffect());
        }
    }

    public IEnumerator DarkShadowEffect()
    {
        yield return new WaitForSeconds(1);
        enemyHealth -= 5;
        yield return new WaitForSeconds(1);
        enemyHealth -= 5;
        yield return new WaitForSeconds(1);
        enemyHealth -= 5;

        DSEffect = false;
        StopCoroutine(DarkShadowEffect());
    }
}
