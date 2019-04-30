using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public TestPlayerScript testPlayerScript;

    [Header("Spell properties and Bools")]
    //FireStream
    public GameObject fireStream;
    public bool usingFireStream = false;

    //AirPush
    public GameObject airPushSpell;
    public GameObject airPushHeld;
    public GameObject airPushPush;
    public ParticleSystem push;
    public bool usingAirPush = false;

    //WaterSpear
    public GameObject waterSpear;
    public bool usingWaterSpear = false;

    //FreezingBolt
    public GameObject freezingBolt;
    public bool usingFreezingBolt = false;

    //FireBombardment
    public GameObject fireBombardment;
    public bool usingFireBombardment = false;

    //BlackMist
    public GameObject blackMist;
    public bool usingBlackMist = false;

    //DarkShadow
    public GameObject darkShadow;
    public bool usingDarkShadow = false;

    // Start is called before the first frame update
    void Start()
    {
        testPlayerScript = GameObject.FindObjectOfType<TestPlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
