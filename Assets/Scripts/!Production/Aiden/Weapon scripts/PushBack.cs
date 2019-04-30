using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PushBack : MonoBehaviour
{

    public float power = 2;
    public float damage = 1;

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Health -= 1;
            other.gameObject.GetComponent<NavMeshAgent>().velocity += transform.forward*power;
        }
    }
}
