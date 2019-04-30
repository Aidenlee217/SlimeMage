using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AgroTrigger : MonoBehaviour
{
    public float timer;

    public float fadetime;

    public Collider[] alloverlappingcolliders;

    public AudioSource AS;
    public AudioClip battle;
    public AudioClip Calm;

    public bool calming = true;

    public void Update()
    {
        if (calming == false)
        {
            if (AS.GetComponent<AudioClip>() == Calm)
            {
                AS.clip = battle;
                AS.Play();
            }
        }
        else
        {
            if (AS.GetComponent<AudioClip>() == battle)
            {
                AS.clip = Calm;
                AS.Play();
            }
        }

        timer += Time.deltaTime;

        if (timer >= 5)
        {
            calming = true;
            alloverlappingcolliders = Physics.OverlapSphere(gameObject.transform.position, gameObject.GetComponent<SphereCollider>().radius);
            for (int i = 0; i < alloverlappingcolliders.Length; i++)
            
                if (alloverlappingcolliders[i].tag == "Enemy")
                {
                    calming = false;
                }
            timer = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Agro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Agro = false;
        }
    }
}
