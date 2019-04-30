using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDealDamage : MonoBehaviour
{
    public EnemyHealth enemyHealthScript;
    public ParticleSystem PS;
    public float damageDealt;

    public void Start()
    {
        PS = this.gameObject.GetComponent<ParticleSystem>();

        Destroy(gameObject, 20);
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
