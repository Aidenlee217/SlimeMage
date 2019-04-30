using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blizzard : MonoBehaviour
{

    public float Damage = 1;
    public float Speed = -1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Health -= Damage;
            other.gameObject.GetComponent<NavMeshAgent>().velocity += new Vector3(-other.gameObject.GetComponent<NavMeshAgent>().velocity.x,0, -other.gameObject.GetComponent<NavMeshAgent>().velocity.z);
        }
    }
}
