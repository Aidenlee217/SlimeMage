using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public PlayerLevelHolder PLH;

    public float materialmult;

    public float timer;
    public float Damage;
    public float originalDamage;
    public float MaxDamage = 10;
    //public float Chargemult = 5;

    // Use this for initialization
    void Start()
    {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
        Leveled();
    }

    void Leveled()
    {
        MaxDamage = (PLH.MeleeLevel / 10) * originalDamage * materialmult;
    }

    private void Update()
    {
        MaxDamage = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Health -= MaxDamage;
        }
    }
}
