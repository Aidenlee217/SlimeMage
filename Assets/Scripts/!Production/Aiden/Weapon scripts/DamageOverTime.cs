using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageOverTime : MonoBehaviour
{

    public PlayerHealth PH;

    public bool freeze = false;
    public bool Regen = false;

    public float damage =0;

    public float timer;
    public float damagetime =1;
    public float lifetimer;
    public float Lifetime = 10f;

    private void Start()
    {
        PH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetimer >= Lifetime)
        {
            timer += Time.deltaTime;
            lifetimer += Time.deltaTime;
            if(freeze == true)
            {
                gameObject.GetComponent<NavMeshAgent>().velocity += new Vector3(-gameObject.GetComponent<NavMeshAgent>().velocity.x, 0, -gameObject.GetComponent<NavMeshAgent>().velocity.z);
            }
            if (timer >= damagetime)
            {
                gameObject.GetComponent<EnemyHealth>().Health -= damage;
                if (Regen == true)
                {
                    PH.Health += (damage / 2);
                }
            }
        }
    }
}
