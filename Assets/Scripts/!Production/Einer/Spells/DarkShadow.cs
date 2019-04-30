using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkShadow : MonoBehaviour
{
    public EnemyHealth enemyHealthScript;

    public float speed;
    public float life;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(speed * transform.forward);
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemyHealthScript = other.gameObject.GetComponent<EnemyHealth>();
        }
    }
}
