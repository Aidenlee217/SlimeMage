using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour {

    public PlayerLevelHolder PLH;

    public float materialmult;

    public float timer;
    public bool LongSword = true;
    public float SSCT = 1;
    public float LSCT = 1.5f;
    public float Damage;
    public float originalDamage;
    public float MaxDamage = 10;
    public float level;
    //public float Chargemult = 5;

	// Use this for initialization
	void Start () {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
        level = PLH.MeleeLevel;
        Leveled();
    }

    void Leveled()
    {
        MaxDamage = (level / 10) * originalDamage* materialmult;
    }
	
	// Update is called once per frame
	void Update () {
        if (LongSword == true)
        {
            if (Damage < MaxDamage)
            {
                timer += Time.deltaTime;

                if(timer<(2/3 * LSCT))
                {
                    Damage = timer * (MaxDamage/LSCT/2);
                }
                else
                {
                    Damage = timer * (MaxDamage/LSCT);
                }
            }
            else
            {
                //timer = 0;
            }
        }
        else
        {
            if (Damage < MaxDamage)
            {
                timer += Time.deltaTime;

                if (timer < (2 / 3 * LSCT))
                {
                    Damage = timer * (MaxDamage / SSCT / 2);
                }
                else
                {
                    Damage = timer * (MaxDamage / SSCT);
                }
            }
            else
            {
                timer = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Health -= Damage;
            Damage = 0;
            timer = 0;
        }
    }
}
