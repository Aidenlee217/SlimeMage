using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public TestPlayerScript playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<TestPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.thirdPerson == true)
        {
            transform.localPosition = new Vector3(0, 0.006688976f, 0.001736688f);
        }
        else
        {
            transform.localPosition = new Vector3(0.0026f, -0.0387f, 0.0095f);
        }
    }
}
