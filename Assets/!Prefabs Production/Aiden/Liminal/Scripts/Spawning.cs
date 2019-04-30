using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public float[] WaveTotalNumbers;
    public float[] wavespecialslimes;

    public float currentwavetotal;
    public float currentwavespecial;

    public int wave = 0;

    public float tempnum;
    public GameObject recent;

    public bool Running = false;

    public float timer;
    public float rate;
    public float waittime;

    public GameObject slime;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waittime)
        {
            if (Running == false)
            {
                StartCoroutine(RunWave());
            }
        }
    }

    IEnumerator RunWave()
    {
        Running = true;
        currentwavetotal = WaveTotalNumbers[wave];
        currentwavespecial = wavespecialslimes[wave];
        while (currentwavetotal > 0)
        {
            tempnum = Random.Range(0, currentwavetotal);
            yield return new WaitForSeconds(rate);
            if (tempnum <currentwavespecial)
            {
                recent = Instantiate(slime, (new Vector3(Random.Range(gameObject.transform.position.x - 30, gameObject.transform.position.x + 30), gameObject.transform.position.y, gameObject.transform.position.z)), Quaternion.identity);
                currentwavetotal -= 1;
                currentwavespecial -= 1;
                recent.GetComponentInChildren<Enemy>().Glowing = true;
                recent.GetComponentInChildren<Enemy>().Updated();
            }
            else
            {
                recent = Instantiate(slime, (new Vector3(Random.Range(gameObject.transform.position.x - 30, gameObject.transform.position.x + 30), gameObject.transform.position.y, gameObject.transform.position.z)), Quaternion.identity);
                currentwavetotal -= 1;
                recent.GetComponentInChildren<Enemy>().Updated();
            }
        }
        timer = 0;
        Running = false;
        wave += 1;
        yield return true;
    }
}
