using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSystem : MonoBehaviour
{
    public GameObject[] spells;
    public GameObject[] shotspells;
    public Image[] pictures;
    public int spellnum = 0;
    public int Maxspell;
    public float[] spellcooldown;
    public float timer;
    public float backgroundtimer;
    public float[] savetimes;
    public bool[] active;

    // Update is called once per frame
    void Update()
    {
        if(active[spellnum] == false)
        {
            spells[spellnum].SetActive(false);
        }
        else
        {
            spells[spellnum].SetActive(true);
        }

        backgroundtimer += Time.deltaTime;
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f)
        {
            if (active[spellnum])
            {
                Instantiate(shotspells[spellnum], gameObject.transform.position, gameObject.transform.rotation);
                savetimes[spellnum] = backgroundtimer;
                timer = 0;
                active[spellnum] = false;
            }
        }
        if (OVRInput.Get(OVRInput.Button.DpadLeft))
        {
            if (spellnum > 0.5f)
            {
                spellnum -= 1;
            }
            else
            {
                spellnum = Maxspell;
            }
            Change();
        }
        if (OVRInput.Get(OVRInput.Button.DpadRight))
        {
            if (spellnum < Maxspell-0.5f)
            {
                spellnum += 1;
            }
            else
            {
                spellnum = 0;
            }
            Change();
        }
        //*****Testing*****
        if (Input.GetButtonDown("Jump"))
        {
            if (active[spellnum])
            {
                Instantiate(shotspells[spellnum], gameObject.transform.position, gameObject.transform.rotation);
                savetimes[spellnum] = backgroundtimer;
                timer = 0;
                active[spellnum] = false;
            }
            spellnum += 1;
            if (spellnum >= Maxspell)
            {
                spellnum = 0;
            }
            Change();
        }
        //*****Testing*****
        //if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -0.5f)
        //{
        //    if (spellnum > 0.5f)
        //    {
        //        spellnum -= 1;
        //    }
        //    else
        //    {
        //        spellnum = Maxspell;
        //    }
        //    Change();
        //}
        //if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0.5f)
        //{
        //    if (spellnum < Maxspell - 0.5f)
        //    {
        //        spellnum += 1;
        //    }
        //    else
        //    {
        //        spellnum = 0;
        //    }
        //    Change();
        //}
        if ((backgroundtimer - savetimes[0]) < spellcooldown[0])
        {
            pictures[0].fillAmount = ((backgroundtimer - savetimes[0]) / spellcooldown[0]);
        }
        else
        {
            active[0] = true;
        }
        if ((backgroundtimer - savetimes[1]) < spellcooldown[1])
        {
            pictures[1].fillAmount = ((backgroundtimer - savetimes[1]) / spellcooldown[0]);
        }
        else
        {
            active[1] = true;
        }
        if ((backgroundtimer - savetimes[2]) < spellcooldown[2])
        {
            pictures[2].fillAmount = ((backgroundtimer - savetimes[2]) / spellcooldown[0]);
        }
        else
        {
            active[2] = true;
        }
        if ((backgroundtimer - savetimes[3]) < spellcooldown[3])
        {
            pictures[3].fillAmount = ((backgroundtimer - savetimes[3]) / spellcooldown[0]);
        }
        else
        {
            active[3] = true;
        }
        if ((backgroundtimer - savetimes[4]) < spellcooldown[4])
        {
            pictures[4].fillAmount = ((backgroundtimer - savetimes[4]) / spellcooldown[0]);
        }
        else
        {
            active[4] = true;
        }
        if ((backgroundtimer - savetimes[5]) < spellcooldown[5])
        {
            pictures[5].fillAmount = ((backgroundtimer - savetimes[5]) / spellcooldown[0]);
        }
        else
        {
            active[5] = true;
        }
    }

    public void Change()
    {
        for(int i = 0; i <= Maxspell; ++i)
        {
            if (i != spellnum)
            {
                spells[i].SetActive(false);
            }
            else
            {
                spells[i].SetActive(true);
            }
        }
    }
}
