using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public float Score;
    public Text Stext;

    public GameObject Spellcontroller;

    public float spell1 = 25;
    public bool s1 = false;
    public float spell2 = 500;
    public bool s2 = false;
    public float spell3 = 1000;
    public bool s3 = false;
    public float spell4 = 2000;
    public bool s4 = false;
    public float spell5 = 4000;
    public bool s5 = false;

    // Update is called once per frame
    void Update()
    {
        Stext.text = "Score : " + Score;
        if (s1 == false)
        {
            if (Score >= spell1)
            {
                s1 = true;
                Run();
            }
        }
        if (s2 == false)
        {
            if (Score >= spell2)
            {
                s2 = true;
                Run();
            }
        }
        if (s3 == false)
        {
            if (Score >= spell3)
            {
                s3 = true;
                Run();
            }
        }
        if (s4 == false)
        {
            if (Score >= spell4)
            {
                s4 = true;
                Run();
            }
        }
        if (s5 == false)
        {
            if (Score >= spell5)
            {
                s5 = true;
                Run();
            }
        }
    }

    void Run()
    {
        Spellcontroller.GetComponent<MagicSystem>().Maxspell += 1;
    }
}
