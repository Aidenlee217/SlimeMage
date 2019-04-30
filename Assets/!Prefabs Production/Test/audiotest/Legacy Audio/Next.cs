using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public float gaptime = 0;
    public AudioClip[] audiolist;
    public AudioSource mainsource;
    public int track = 0;
    public bool ending = false;

    float timer;
    //public float tracktime;

    //public GameObject next;

    private void Start()
    {
        mainsource.clip = audiolist[track];
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if (timer >= tracktime)
        //{
        //    if (next != null)
        //    {
        //        Instantiate(next);
        //    }
        //    Destroy(gameObject);
        //}

        if(timer>= audiolist[track].length+gaptime)
        {
            timer = 0;
            track += 1;
            if (ending == false)
            {
                if (track == audiolist.Length - 1)
                {
                    track = 1;
                }
            }
            next();
        }
    }

    public void next()
    {
        mainsource.clip = audiolist[track];
        mainsource.Play();
    }
}
