using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spawner")
        {
            other.gameObject.GetComponent<EnemySpawner>().Activate();
        }
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().CurrentIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("exited trigger" + other.gameObject.name);
            other.gameObject.GetComponent<EnemyHealth>().CurrentIn = false;
            if (other.gameObject.GetComponent<EnemyHealth>().ActiveSpawn == false)
            {
                other.gameObject.GetComponent<EnemyHealth>().Despawn();
                Debug.Log("TriggerDespawn");
            }
        }
        if(other.gameObject.tag == "Spawner")
        {
            Debug.Log("spawnerdeactivated run");
            other.gameObject.GetComponent<EnemySpawner>().Deactivate();
        }
    }

}
