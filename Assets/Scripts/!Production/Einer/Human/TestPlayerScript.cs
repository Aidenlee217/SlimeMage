using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerScript : MonoBehaviour
{
    public Transform TPTarget;
    public Transform FPTarget;

    [Header("Audio")]
    public AudioClip A_airPushHeld;
    public AudioClip A_airPushCast;
    public AudioClip A_blackMistHeld;
    public AudioClip A_blackMistCast;
    public AudioClip A_darkShadowHeld;
    public AudioClip A_darkShadowCast;
    public AudioClip A_fireBombardmentHeld;
    public AudioClip A_fireBombardmentCast;
    public AudioClip A_fireStreamHeld;
    public AudioClip A_fireStreamCast;
    public AudioClip A_LightningTouchHeld;
    public AudioClip A_lightningTouchCast;

    public AudioClip A_bowDraw;
    public AudioClip A_bowFire;

    public AudioSource audi;

    [Header("Health and Magic")]

    //Magic Properties
    public float health;
    public PlayerHealth PHS;

    public Image ManaBar;
    public float Mana;
    public float maxMana = 100;

    [Header("Movement")]
    public Quaternion newrotation;
    public float smooth = 0.05f;
    public float movementSpeed = 2;
    public float sprintSpeed = 4;
    Animator anim;

    public bool isAiming = false;

    [Header("ThirdPerson")]
    public Camera ThirdPersonCam;
    public Transform TPCamera;
    public bool thirdPerson = true;

    [Header("FirstPerson")]
    public Camera FirstPersonCam;
    public Transform FPCamera;
    public bool firstPerson = false;

    [Header("Slots")]
    public GameObject rightArmSlot;

    [Header("Stances")]
    public bool meleeStance = false;
    public bool rangeStance = false;
    public bool magicStance = false;
    public bool noStance = false;

    [Header("Attacking")]
    public GameObject weapon;
    public GameObject atkCollider;

    public int attacknumber = 0;
    public float clicktime = 0;

    [Header("Shooting")]
    public GameObject bow;
    public GameObject arrow;
    public GameObject spawnedArrow;
    public GameObject heldArrow;
    public Transform arrowSpawn;

    public float arrowCooldown = 0;

    public float arrowPower;
    public float arrowDamage;


    [Header("Spell properties and Bools")]
    public bool charging = false;

    //FireStream
    public GameObject fireStream;
    public ParticleSystem fire;
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
    public GameObject fireBombardmentHeld;
    public GameObject fireBombardment;
    public ParticleSystem fireBombardmentPS;    
    public bool usingFireBombardment = false;

    //BlackMist
    public GameObject blackMistHeld;
    public GameObject blackMist;
    public ParticleSystem blackMistPS;
    public bool usingBlackMist = false;

    //DarkShadow
    public GameObject darkShadow;
    public GameObject darkShadowBeam;
    public bool usingDarkShadow = false;

    //LightingTouch
    public GameObject lightningTouch;
    public bool usingLightningTouch = false;

    [Header("Ignore")]
    //Ignore
    public int layer1;
    public int layer2;

    //Nothing
    public bool usingNothing;  


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();

        rightArmSlot = GameObject.Find("Right Arm Slot Magic");
        atkCollider = GameObject.FindGameObjectWithTag("Attack Collider");
        PHS = GameObject.FindObjectOfType<PlayerHealth>();
        atkCollider.SetActive(false);

        Mana = ManaBar.fillAmount * 100;

        bow = GameObject.Find("Bow");
        heldArrow.SetActive(false);

        airPushSpell.SetActive(false);
        blackMistHeld.SetActive(false);
        darkShadow.SetActive(false);
        fireBombardmentHeld.SetActive(false);
        fireStream.SetActive(false);
        freezingBolt.SetActive(false);
        waterSpear.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Declare Methods//
        HealthAndMagic();
        Stances();
        MeleeAttacking();
        RangeAttacking();
        SpellSelect();
        SpellShoot();

                    //Perspectives//
        //Change Perspectives
        if (Input.GetButtonDown("T"))
        {
            if(thirdPerson == false)
            {
                FirstPersonCam.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            thirdPerson = !thirdPerson;
            firstPerson = !firstPerson;            
        }

        //Check whether it's third person or first person perspective
        //Then set the appropriate movement
        if (thirdPerson == true)
        {
            ThirdPersonCam.enabled = true;
            FirstPersonCam.enabled = false;
            anim.SetBool("FirstPerson", false);
            anim.SetBool("ThirdPerson", true);
            FirstPersonCam.GetComponent<TestFPCamera>().enabled = false;
            firstPerson = false;

            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            if(isAiming == false)
            {
                TPmovement(v, h);
            }                        
        }
        else
        {
            ThirdPersonCam.enabled = false;
            FirstPersonCam.enabled = true;
            anim.SetBool("FirstPerson", true);
            anim.SetBool("ThirdPerson", false);
            FirstPersonCam.GetComponent<TestFPCamera>().enabled = true;
            thirdPerson = false;

            anim.SetFloat("speed", 0);

            if (isAiming == false)
            {
                FPmovement();
            }            
        }

        //other
        Physics.IgnoreLayerCollision(layer1, layer2, true);
    }


    //Health and Magic
    public void HealthAndMagic()
    {
        health = PHS.Health;

        //Mana Set
        ManaBar.fillAmount = Mana / 100;

        //Mana Regen
        if (Mana >= maxMana)
        {
            Mana = maxMana;
        }
        else
        {
            Mana += Time.deltaTime*2.5f;
        }
    }

    //Third Person Movement Controls
    void TPmovement(float v, float h)
    {
        //checking if the user pressed any keys
        if (h != 0f || v != 0f)
        {
            //rotates the player in the intended direction
            TProtate(v, h);

            //then move the player in that direction
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("speed", 2);
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * sprintSpeed * 2.5f;
            }
            else
            {
                anim.SetFloat("speed", 1);
                transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            }           
        }
        else
        {
            anim.SetFloat("speed", 0);
            //Stop the player if user is not pressing any key
        }
    }

    void TProtate(float v, float h)
    {
        if (v > 0)
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 45, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 305, 0);
            }
            else
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y, 0);
            }
        }
        else if (v < 0)
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 135, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 225, 0);
            }
            else
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 180, 0);
            }
        }
        else
        {
            if (h > 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 90, 0);
            }
            else if (h < 0)
            {
                newrotation = Quaternion.Euler(0, TPCamera.eulerAngles.y + 270, 0);
            }
            else
            {
                newrotation = transform.rotation;
            }
        }

        //We only want player to rotate in y axis
        newrotation.x = 0;
        newrotation.z = 0;

        //Slerp from player's current rotation to the new intended rotation smoothly
        transform.rotation = Quaternion.Slerp(transform.rotation, newrotation, smooth);
        
    }
    

    //First Person Movement
    void FPmovement()
    {
        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float straffe = Input.GetAxis("Horizontal") * movementSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            translation *= Time.deltaTime * sprintSpeed;
            straffe *= Time.deltaTime * sprintSpeed;
        }
        else
        {
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;
        }           

        transform.Translate(straffe, 0, translation);
    }


    //Stances
    void Stances()
    {
        if(Input.GetButtonDown("C"))
        {            
            meleeStance = true;
            rangeStance = false;
            magicStance = false;
            noStance = false;
        }

        if (Input.GetButtonDown("V"))
        {
            meleeStance = false;
            rangeStance = true;
            magicStance = false;
            noStance = false;
        }

        if (Input.GetButtonDown("B"))
        {
            meleeStance = false;
            rangeStance = false;
            magicStance = true;
            noStance = false;
        }

        if(Input.GetButtonDown("R"))
        {
            meleeStance = false;
            rangeStance = false;
            magicStance = false;
        }

        if(noStance == true)
        {
            meleeStance = false;
            rangeStance = false;
            magicStance = false;
        }

    }


    //Melee Attacking
    void MeleeAttacking()
    {         
        if (meleeStance == true)
        {
            anim.SetBool("MeleeState", true);

            clicktime += Time.deltaTime;

            if (weapon != null)
            {
                weapon.SetActive(true);

                if (Input.GetButtonDown("Fire1"))
                {
                    ++attacknumber;
                    clicktime = 0;

                    if (attacknumber == 1)
                    {
                        atkCollider.SetActive(true);
                    }
                    else if (attacknumber == 2)
                    {
                        atkCollider.SetActive(true);
                    }
                    else
                    {
                        atkCollider.SetActive(false);
                    }
                }
                else
                {
                    atkCollider.SetActive(false);
                }
            }           

            if (clicktime >= .5f)
            {
                attacknumber = 0;
            }

            if(attacknumber > 5)
            {
                attacknumber = 0;
            }

            anim.SetInteger("Attacks", attacknumber);
            rangeStance = false;
            magicStance = false;
        }
        else
        {
            if(weapon != null)
            {
                weapon.SetActive(false);
            }            
            anim.SetBool("MeleeState", false);
        }
    }


    //Range Attacking
    void RangeAttacking()
    {
        arrowCooldown -= Time.deltaTime;

        if (arrowCooldown <= 0)
        {
            arrowCooldown = 0;
        }

        if (rangeStance == true)
        {
            bow.SetActive(true);

            Vector3 targetPosition;            

            if (thirdPerson == true)
            {
                targetPosition = new Vector3(TPTarget.transform.position.x, transform.position.y, TPTarget.transform.position.z);
            }
            else
            {
                targetPosition = new Vector3(FPTarget.transform.position.x, transform.position.y, FPTarget.transform.position.z);
            }
            anim.SetBool("RangeState", true);

            if(arrowCooldown == 0)
            {
                if (Input.GetButton("Fire1"))
                {
                    isAiming = true;
                    heldArrow.SetActive(true);
                    arrowPower += Time.deltaTime;
                    anim.SetBool("isShooting", true);

                    if (arrowPower >= 3)
                    {
                        arrowPower = 3;
                    }

                    //audi.clip = A_bowDraw;
                    //audi.Play();
                }
                else
                {
                    if (isAiming == true)
                    {
                        heldArrow.SetActive(false);
                        spawnedArrow = Instantiate(arrow, arrowSpawn.position, Quaternion.identity) as GameObject;

                        if (thirdPerson == true)
                        {
                            spawnedArrow.GetComponent<Rigidbody>().velocity = TPCamera.transform.forward * arrowPower * 20;
                            arrowDamage = arrowPower *20;
                        }
                        else
                        {
                            spawnedArrow.GetComponent<Rigidbody>().velocity = FPCamera.transform.forward * arrowPower * 20;
                            arrowDamage = arrowPower * 20;
                        }
                        arrowPower = 0;

                        arrowCooldown = .8f;

                        isAiming = false;
                    }

                    isAiming = false;
                    anim.SetBool("isShooting", false);
                }
                if(isAiming == true)
                {
                    audi.clip = A_bowDraw;
                    audi.Play();
                }

            }            

            if (isAiming == true)
            {
                transform.LookAt(targetPosition);

                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
                {
                    transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
                    anim.SetFloat("speed", 2);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }
                else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
                {
                    transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
                    anim.SetFloat("speed", 1);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);

                }
                else if (Input.GetKey("s"))
                {
                    transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
                    anim.SetFloat("speed", 1);
                    anim.SetBool("isWalkingBackwards", true);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);

                }
                else if (Input.GetKey("a"))
                {
                    transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;                    
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetFloat("speed", 1);
                    anim.SetBool("isWalkingLeft", true);
                    anim.SetBool("isWalkingRight", false);

                }
                else if (Input.GetKey("d"))
                {
                    transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
                    anim.SetFloat("speed", 1);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);

                }
                else
                {
                    anim.SetFloat("speed", 0);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                }
            }

            noStance = false;
            meleeStance = false;
            magicStance = false;
        }
        else
        {
            bow.SetActive(false);
        }
    }
    

    //Choosing a spell and setting it active
    void SpellSelect()
    {
        if(magicStance == true)
        {
            anim.SetBool("MagicState", true);

            usingNothing = false;

            //FireStream
            if (Input.GetKeyDown("[1]"))
            {
                //Instantiate(fireStream, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);
                fire = fireStream.GetComponent<ParticleSystem>();

                usingAirPush = false;
                usingBlackMist = false;
                usingDarkShadow = false;
                usingFireBombardment = false;
                usingFireStream = true;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = false;
            }

            //AirPush
            if (Input.GetKeyDown("[2]"))
            {
                //airPushHeld = Instantiate(airPushSpell, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent) as GameObject;
                               

                usingAirPush = true;
                usingBlackMist = false;
                usingDarkShadow = false;
                usingFireBombardment = false;
                usingFireStream = false;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = false;
            }

            ////WaterSpear
            //if (Input.GetKeyDown("[9]"))
            //{
            //    //Instantiate(waterSpear, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);

            //    usingAirPush = false;
            //    usingBlackMist = false;
            //    usingDarkShadow = false;
            //    usingFireBombardment = false;
            //    usingFireStream = false;
            //    usingFreezingBolt = false;
            //    usingWaterSpear = true;
            //    usingLightningTouch = false;
            //}

            //FreezingBolt
            //if (Input.GetKeyDown("[8]"))
            //{
            //    Instantiate(freezingBolt, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);

            //    usingAirPush = false;
            //    usingBlackMist = false;
            //    usingDarkShadow = false;
            //    usingFireBombardment = false;
            //    usingFireStream = false;
            //    usingFreezingBolt = true;
            //    usingWaterSpear = false;
            //    usingLightningTouch = false;
            //}

            //FireBombardment
            if (Input.GetKeyDown("[3]"))
            {
                //Instantiate(fireBombardment, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);

                usingAirPush = false;
                usingBlackMist = false;
                usingDarkShadow = false;
                usingFireBombardment = true;
                usingFireStream = false;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = false;
            }

            //BlackMist
            if (Input.GetKeyDown("[4]"))
            {
                //Instantiate(blackMist, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);

                usingAirPush = false;
                usingBlackMist = true;
                usingDarkShadow = false;
                usingFireBombardment = false;
                usingFireStream = false;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = false;
            }

            //DarkShadow
            if (Input.GetKeyDown("[5]"))
            {
                //Instantiate(darkShadow, rightArmSlot.transform.position, rightArmSlot.transform.rotation, rightArmSlot.transform.parent);

                usingAirPush = false;
                usingBlackMist = false;
                usingDarkShadow = true;
                usingFireBombardment = false;
                usingFireStream = false;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = false;
            }

            //LightningTouch
            if (Input.GetKeyDown("[6]"))
            {
                usingAirPush = false;
                usingBlackMist = false;
                usingDarkShadow = false;
                usingFireBombardment = false;
                usingFireStream = false;
                usingFreezingBolt = false;
                usingWaterSpear = false;
                usingLightningTouch = true;
            }

            meleeStance = false;
            rangeStance = false;
        }
        else
        {
            anim.SetBool("MagicState", false);

            usingAirPush = false;
            usingBlackMist = false;
            usingDarkShadow = false;
            usingFireBombardment = false;
            usingFireStream = false;
            usingFreezingBolt = false;
            usingWaterSpear = false;
            usingLightningTouch = false;

            usingNothing = true;
        }
    }


    //Instantiating/Casting the Spell
    void SpellShoot()
    {
        Vector3 targetPosition = new Vector3(TPTarget.transform.position.x, transform.position.y, TPTarget.transform.position.z);


        //AirPush
        if (usingAirPush == true)
        {
            airPushSpell.SetActive(true);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            audi.clip = A_airPushHeld;
            audi.Play();

            if (Mana >= 30)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    airPushPush = airPushSpell.transform.GetChild(0).gameObject;
                    push = airPushPush.GetComponent<ParticleSystem>();

                    if (thirdPerson == true)
                    {
                        airPushSpell.transform.forward = ThirdPersonCam.transform.forward;
                    }
                    else
                    {
                        airPushSpell.transform.forward = FirstPersonCam.transform.forward;
                    }

                    push.Emit(100);

                    transform.LookAt(targetPosition);

                    Mana -= 30;

                    audi.clip = A_airPushCast;
                    audi.Play();

                    anim.SetBool("MagicAttackBlast", true);
                }
                else
                {
                    anim.SetBool("MagicAttackBlast", false);
                }
            }
            else
            {
                anim.SetBool("MagicAttackBlast", false);
            }
        }
        else
        {
            audi.clip = null;
        }

        //BlackMist
        if (usingBlackMist == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(true);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            blackMistPS = blackMistHeld.GetComponent<ParticleSystem>();

            if(Mana >= 100)
            {
                if (Input.GetButton("Fire1"))
                {
                    charging = true;
                    blackMistPS.emissionRate = 100;
                    blackMistPS.startSpeed = 2;
                    blackMistPS.startLifetime = 1.5f;
                }
                else
                {
                    blackMistPS.emissionRate = 50;
                    blackMistPS.startSpeed = .7f;
                    blackMistPS.startLifetime = 1;

                    if (charging == true)
                    {
                        charging = false;

                        if (thirdPerson == true)
                        {
                            transform.LookAt(targetPosition);
                            Instantiate(blackMist, blackMistHeld.transform.position, ThirdPersonCam.transform.rotation);
                            Mana -= 100;
                            anim.SetBool("MagicAttackBlast", true);
                        }
                        else
                        {
                            Instantiate(blackMist, blackMistHeld.transform.position, FirstPersonCam.transform.rotation);
                            Mana -= 100;
                            anim.SetBool("MagicAttackBlast", true);
                        }

                        audi.clip = A_blackMistCast;
                        audi.Play();

                    }
                    else
                    {
                        anim.SetBool("MagicAttackBlast", false);
                    }
                }
            }
            else
            {
                anim.SetBool("MagicAttackBlast", false);
            }
        }

        //DarkShadow
        if (usingDarkShadow == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(true);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            if (Mana >= 80)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (thirdPerson == true)
                    {
                        Instantiate(darkShadowBeam, darkShadow.transform.position, ThirdPersonCam.transform.rotation);
                        Mana -= 80;
                    }
                    else
                    {
                        Instantiate(darkShadowBeam, darkShadow.transform.position, FirstPersonCam.transform.rotation);
                        Mana -= 80;
                    }

                    audi.clip = A_darkShadowCast;
                    audi.Play();

                    anim.SetBool("MagicAttackBlast", true);
                }
                else
                {
                    anim.SetBool("MagicAttackBlast", false);
                }
            }
            else
            {
                anim.SetBool("MagicAttackBlast", false);
            }
        }

        //FireBombardment
        if (usingFireBombardment == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(true);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            fireBombardmentPS = fireBombardmentHeld.GetComponent<ParticleSystem>();

            if (Mana >= 100)
            {
                if (Input.GetButton("Fire1"))
                {
                    charging = true;
                    fireBombardmentPS.Emit(100);
                    fireBombardmentPS.startSpeed = -2;
                    fireBombardmentPS.startLifetime = .5f;
                }
                else
                {
                    fireBombardmentPS.Emit(0);
                    fireBombardmentPS.startSpeed = -1;
                    fireBombardmentPS.startLifetime = 1f;

                    if (charging == true)
                    {
                        charging = false;

                        if (thirdPerson == true)
                        {
                            transform.LookAt(targetPosition);
                            Instantiate(fireBombardment, fireBombardmentHeld.transform.position, ThirdPersonCam.transform.rotation);
                            Mana -= 100;
                            anim.SetBool("MagicAttackBlast", true);
                        }
                        else
                        {
                            Instantiate(fireBombardment, fireBombardmentHeld.transform.position, FirstPersonCam.transform.rotation);
                            Mana -= 100;
                            anim.SetBool("MagicAttackBlast", true);
                        }

                        audi.clip = A_fireBombardmentCast;
                        audi.Play();
                    }
                    else
                    {
                        anim.SetBool("MagicAttackBlast", false);
                    }
                }
            }
            else
            {
                anim.SetBool("MagicAttackBlast", false);
            }


        }

        //FireStream
        if (usingFireStream == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(true);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            if (Mana >= 1)
            {
                if (Input.GetButton("Fire1"))
                {
                    var emission = fire.emission;
                    emission.rateOverTime = 100f;
                    var main = fire.main;
                    main.startSpeed = 4;
                    var coll = fire.collision;
                    coll.enabled = true;

                    transform.LookAt(targetPosition);

                    Mana -= 1;

                    if (thirdPerson == true)
                    {
                        fireStream.transform.forward = ThirdPersonCam.transform.forward;
                    }
                    else
                    {
                        fireStream.transform.forward = FirstPersonCam.transform.forward;
                    }

                    anim.SetBool("MagicAttackHold", true);

                    audi.clip = A_fireStreamCast;
                    audi.Play();
                }
                else
                {
                    var emission = fire.emission;
                    emission.rateOverTime = 50f;
                    var main = fire.main;
                    main.startSpeed = .6f;
                    var coll = fire.collision;
                    coll.enabled = false;

                    anim.SetBool("MagicAttackHold", false);
                }
            }
            else
            {
                anim.SetBool("MagicAttackHold", false);
            }
        }

        //FreezingBolt
        if (usingFreezingBolt == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(true);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);

            if (Mana >= 30)
            {
                if (Input.GetButton("Fire1"))
                {
                    //    Instantiate(darkShadowBeam, darkShadow.transform.position, ThirdPersonCam.transform.rotation);

                    //    Mana -= 30;

                    //    anim.SetBool("MagicAttackBlast", true);
                    //}
                    //else
                    //{
                    //    anim.SetBool("MagicAttackBlast", false);
                    //}
                }
            }
            //else
            //{
            //    anim.SetBool("MagicAttackBlast", false);
            //}
        }

        //Spear
        if (usingWaterSpear == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(true);
            lightningTouch.SetActive(false);

            if (Mana >= 20)
            {
                if (Input.GetButton("Fire1"))
                {
                    //Mana -= 20;
                }
            }
            else
            {
                anim.SetBool("MagicAttackHold", false);
            }
        }

        //Lightning Touch
        if (usingLightningTouch == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(true);

            if (Mana >= 1)
            {
                if (Input.GetButton("Fire1"))
                {
                    anim.SetBool("MagicAttackHold", true);
                    Mana -= 1;
                }
                else
                {
                    anim.SetBool("MagicAttackHold", false);
                }
            }
            else
            {
                anim.SetBool("MagicAttackHold", false);
            }
        }

        if(usingNothing == true)
        {
            airPushSpell.SetActive(false);
            blackMistHeld.SetActive(false);
            darkShadow.SetActive(false);
            fireBombardmentHeld.SetActive(false);
            fireStream.SetActive(false);
            freezingBolt.SetActive(false);
            waterSpear.SetActive(false);
            lightningTouch.SetActive(false);
        }

    }
}
