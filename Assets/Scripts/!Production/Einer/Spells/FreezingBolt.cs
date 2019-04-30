using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingBolt : MonoBehaviour
{
    public float speed;
    public float life;
    public float damageDealt;

    public EnemyHealthScript enemyHealthScript;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(speed * transform.forward);
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyHealthScript = other.gameObject.GetComponent<EnemyHealthScript>();
            enemyHealthScript.enemyHealth -= damageDealt;
        }
    }
}