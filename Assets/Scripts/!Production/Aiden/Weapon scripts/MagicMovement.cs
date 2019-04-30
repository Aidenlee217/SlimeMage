using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMovement : MonoBehaviour {

    public bool TOD = false;

    public float Speed = 5;
    public float lifetime = 5;
    public float timer;
    public float Damage = 5;
    public GameObject Hit;
    public bool detonate = false;

    public GameObject flare;
    public GameObject trail;
    public bool hit = false;
    public bool contacted = false;

    void Start()
    {
        gameObject.transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        gameObject.transform.Translate(0, 0, Speed * Time.deltaTime);
        if (timer >= lifetime)
        {
            detonate = true;
            Detonate();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (timer <= 0.1)
        {
            if (collision.gameObject.tag != "Enemy")
            {
                return;
            }
        }
        detonate = true;
        if (contacted == false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().Health -= Damage;
                if(TOD == true)
                {
                    collision.gameObject.AddComponent<DamageOverTime>();
                    collision.gameObject.GetComponent<DamageOverTime>().Regen = true;
                    collision.gameObject.GetComponent<DamageOverTime>().damage = 30;
                }
            }
            contacted = true;
        }
        Debug.Log("Collided with " + collision.gameObject.name);
        Detonate();
    }

    void Detonate()
    {
        StartCoroutine(Destroy());
        //Instantiate(Hit, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator Destroy()
    {
        Speed = 0;
        //Destroy(flare);
        flare.SetActive(false);
        if(hit == false)
        {
            Instantiate(Hit, gameObject.transform.position, gameObject.transform.rotation);
            hit = true;
        }
        yield return new WaitForSeconds(1);
        //Destroy(trail);
        trail.SetActive(false);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return "Success";
    }
}
