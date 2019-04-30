using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicskyattack : MonoBehaviour {

    public GameObject Spell;
    public GameObject[] castedspells;
    public float spellcount = 5;
    public int counter;
    public float spellspeed = 5;
    public float timer;
    public float waittime = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (counter < spellcount)
        {
            if (timer >= waittime)
            {
                castedspells[counter] = Instantiate(Spell, new Vector3(Random.Range(gameObject.transform.position.x - 5, gameObject.transform.position.x + 5), gameObject.transform.position.y + 10, Random.Range(gameObject.transform.position.z - 5, gameObject.transform.position.z + 5)), Quaternion.identity);
                counter += 1;
                timer = 0;
            }
        }
        for (int i = 0; i < spellcount; i++)
        {
            if(castedspells[i] != null)
            {
                castedspells[i].transform.position = Vector3.MoveTowards(castedspells[i].transform.position, gameObject.transform.position, spellspeed * Time.deltaTime);
            }
        }
        //if (counter < spellcount)
        //{
        //    if (step == true)
        //    {
        //        for (int i = 0; i < counter; ++i)
        //        {
        //            castedspells[counter] = Instantiate(Spell, new Vector3(Random.Range(gameObject.transform.position.x - 5, gameObject.transform.position.x + 5), gameObject.transform.position.y + 10, Random.Range(gameObject.transform.position.z - 5, gameObject.transform.position.z + 5)), Quaternion.identity);
        //            counter += 1;
        //            step = false;
        //            StartCoroutine(Cast());
        //        }
        //    }
        //}
        //if (counter >= spellcount)
        //{
        //    for (int i = 0; i < spellcount; i++)
        //    {
        //        castedspells[i].transform.position = Vector3.MoveTowards(castedspells[i].transform.position, gameObject.transform.position, spellspeed * Time.deltaTime);
        //    }
        //}
    }
}
