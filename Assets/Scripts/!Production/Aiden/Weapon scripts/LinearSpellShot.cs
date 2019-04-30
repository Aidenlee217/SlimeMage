using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearSpellShot : MonoBehaviour
{
    public float timer;

    public GameObject Hit;

    public float speed =10;
    public float damage =15;

    public bool Freeze = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timer > 0.1f)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().Health -= damage;
                if (Freeze == true)
                {
                    collision.gameObject.AddComponent<DamageOverTime>();
                    collision.gameObject.GetComponent<DamageOverTime>().freeze = true;
                    collision.gameObject.GetComponent<DamageOverTime>().freeze = true;
                    collision.gameObject.GetComponent<DamageOverTime>().freeze = true;
                    if (Hit != null)
                    {
                        Instantiate(Hit, gameObject.transform.position, Quaternion.identity);
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (timer > 0.1f)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().Health -= damage;
                if (Hit != null)
                {
                    Instantiate(Hit, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
    }
}
