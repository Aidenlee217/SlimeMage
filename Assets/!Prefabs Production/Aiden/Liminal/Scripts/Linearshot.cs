using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linearshot : MonoBehaviour
{
    public float speed;
    public float timer;
    public float lifetime;
    public GameObject hit;
    public GameObject Cast;
    public bool singlehit = false;
    public bool mapclear = false;

    void Start()
    {
        Instantiate(Cast, gameObject.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.Translate(0,0,speed*Time.deltaTime);
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(singlehit == false)
        {
            if (mapclear == true)
            {
                if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Enemy>().Death();
                    other.gameObject.GetComponent<AudioSource>().enabled = false;
                    other.gameObject.GetComponent<Collider>().enabled = false;
                }
            }
            else
            {
                if (other.gameObject.tag == "Enemy")
                {
                    other.gameObject.GetComponent<Enemy>().Death();
                    //Instantiate(hit, other.gameObject.transform);
                    other.gameObject.GetComponent<Collider>().enabled = false;
                }
            }
        }
        else
        {
            //if (other.gameObject.tag == "Enemy")
            //{
            //    other.gameObject.GetComponent<Enemy>().Death();
            //    Instantiate(hit, other.gameObject.transform);
            //    Destroy(gameObject);
            //}
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Death();
            if (hit != null)
            {
                Instantiate(hit, gameObject.transform.position,Quaternion.identity);
            }
            collision.gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
        else
        {
            if (hit != null)
            {
                Instantiate(hit, gameObject.transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
