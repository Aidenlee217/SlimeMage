using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour {

    public float Speed = 5;
    public float lifetime = 5;
    public float timer;
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
    void Update()
    {
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
        if (timer <= 0.025f)
        {
            if (collision.gameObject.tag != "Enemy")
            {
                
            }
            else
            {
                detonate = true;
                Debug.Log("Collided with " + collision.gameObject.name);
                Detonate();
            }
        }
        else
        {
            detonate = true;
            Debug.Log("Collided with " + collision.gameObject.name);
            Detonate();
        }
    }

    void Detonate()
    {
        StartCoroutine(Destroy());
        //Instantiate(Hit, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator Destroy()
    {
        Speed = 0;
        flare.SetActive(false);
        //Destroy(flare);
        if (hit == false)
        {
            Instantiate(Hit, gameObject.transform.position, new Quaternion(0,gameObject.transform.rotation.y,0,1));
            hit = true;
        }
        yield return new WaitForSeconds(1);
        trail.SetActive(false);
        //Destroy(trail);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return "Success";
    }
}
