using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomeDamage : MonoBehaviour {

    public float timer;
    public GameObject dome;
    public float Damage;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Collider[] alloverlappingcolliders = Physics.OverlapSphere(gameObject.transform.position, dome.transform.localScale.x/2);
            for (int i = 0; i < alloverlappingcolliders.Length; i++)
            {
                if (alloverlappingcolliders[i].gameObject.tag == "Enemy")
                {
                    alloverlappingcolliders[i].gameObject.GetComponent<EnemyHealth>().Health -= Damage;
                }
                else
                {
                    Debug.Log("Failed Damage; " + alloverlappingcolliders[i].name);
                }
            }
            timer = 0;
        }

    }
}
