using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestream : MonoBehaviour
{
    public EnemyHealth enemyHealthScript;
    public ParticleSystem PS;
    public float damageDealt;

    public void Start()
    {
        PS = this.gameObject.GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealthScript = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealthScript.Health -= damageDealt;
        }
    }
}
