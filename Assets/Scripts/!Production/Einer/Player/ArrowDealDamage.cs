using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDealDamage : MonoBehaviour
{
    PlayerLevelHolder PLH;
    TestPlayerScript player;

    public float damage = 200;

    public float totaldamage;

    public float matmult = 1;

    // Use this for initialization
    void Start()
    {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
        player = GameObject.FindObjectOfType<TestPlayerScript>();
        totaldamage = player.arrowDamage * (PLH.RangeLevel / 10 * matmult);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().Health -= player.arrowDamage;
            collision.gameObject.GetComponent<EnemyHealth>().Rangedone += totaldamage;
            collision.gameObject.GetComponent<EnemyHealth>().Agro = true;
        }
    }

}
