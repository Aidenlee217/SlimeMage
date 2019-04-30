using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLaunch : MonoBehaviour {

    PlayerLevelHolder PLH;

    public float RLevel;

    public float damage = 200;
    public float totaldamage;

    public float matmult = 1;

    public float multiplyer;
    public float force;

    public float lifetime = 7.5f;
    public float timer;

    // Use this for initialization
    void Start () {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
        RLevel = PLH.RangeLevel;
        totaldamage = damage* (RLevel / 10 * matmult);
        gameObject.GetComponent<Rigidbody>().AddForce((force * multiplyer) * transform.forward);
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
        transform.LookAt(transform.position + gameObject.GetComponent<Rigidbody>().velocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().Health -= totaldamage;
            collision.gameObject.GetComponent<EnemyHealth>().Rangedone += totaldamage;
            collision.gameObject.GetComponent<EnemyHealth>().Agro = true;
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
