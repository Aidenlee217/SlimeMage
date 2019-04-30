using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{

    public float Damage;

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Health -= Damage;
        }
    }
}
