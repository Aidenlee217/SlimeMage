using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //Health Properties
	public Image healthBar;
    public float damageDealt;
    
	//Movement
	public float movementSpeed;

	//Attack Properties
    private GameObject attackCollider;
    public GameObject arrowPrefab;
    public Transform arrowSpawn;

	//Magic
	public bool usingFire;
	public GameObject fireBall;
	public bool usingIce;
    public GameObject healingRing;
	public bool usingShock;
	public bool usingHeal;

	//Stances
    public bool meleeStance;
    public bool rangeStance;
	public bool	magicStance;

    //Scripts
    public EquipmentManager_E equipmentManager;

	//PlayerSlots
	private GameObject RightArmSlot;

	//Animator
	Animator anim;
    public int clickCount = 0;
    public bool attack1Done = false;
    public bool attack2Done = false;
    public bool attack3Done = false;

    // Use this for initialization
    void Start ()
    {
        attackCollider = GameObject.FindGameObjectWithTag("Attack Collider");
        attackCollider.SetActive(false);

		RightArmSlot = GameObject.Find("Right Arm Slot");

        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
    {
        Attacks();
		Stances();
		SelectSpells();
		Move();
    }

	public void Move()
	{
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey ("w")) 
		{
            transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;			
			anim.SetBool("isRunning", true);
			anim.SetBool("isJogging", false);
			anim.SetBool("isWalkingBackwards", false);
			anim.SetBool("isJoggingRight", false);
			anim.SetBool("isJoggingleft", false);
        }   
		else if (Input.GetKey ("w") && !Input.GetKey (KeyCode.LeftShift)) 
		{
            transform.position += transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;			
			anim.SetBool("isRunning", false);
			anim.SetBool("isJogging", true);
			anim.SetBool("isWalkingBackwards", false);
			anim.SetBool("isJoggingRight", false);
			anim.SetBool("isJoggingleft", false);
        }   
		else if (Input.GetKey ("s")) 
		{
            transform.position -= transform.TransformDirection (Vector3.forward) * Time.deltaTime * movementSpeed;			
			anim.SetBool("isRunning", false);
			anim.SetBool("isJogging", false);
			anim.SetBool("isWalkingBackwards", true);
			anim.SetBool("isJoggingRight", false);
			anim.SetBool("isJoggingleft", false);
        }
 
        else if (Input.GetKey ("a") && !Input.GetKey ("d")) 
		{
            transform.position += transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
			anim.SetBool("isRunning", false);
			anim.SetBool("isJogging", false);
			anim.SetBool("isWalkingBackwards", false);
			anim.SetBool("isJoggingRight", false);
			anim.SetBool("isJoggingleft", true);
        } 
		else if (Input.GetKey ("d") && !Input.GetKey ("a")) 
		{
            transform.position -= transform.TransformDirection (Vector3.left) * Time.deltaTime * movementSpeed;
			anim.SetBool("isRunning", false);
			anim.SetBool("isJogging", false);
			anim.SetBool("isWalkingBackwards", false);
			anim.SetBool("isJoggingRight", true);
			anim.SetBool("isJoggingleft", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJogging", false);
            anim.SetBool("isWalkingBackwards", false);
            anim.SetBool("isJoggingRight", false);
            anim.SetBool("isJoggingleft", false);
        }
	}

	void Stances()
	{
		if (Input.GetButtonDown("T"))
		{
			MeleeStance();
		}

		if (Input.GetButtonDown("Y"))
		{
			RangeStance();
		}

		if (Input.GetButtonDown("U"))
		{
			MagicStance();
		}
	}

    void MeleeStance()
    {
        rangeStance = false;
        meleeStance = true;
		magicStance	= false;
    }

    void RangeStance()
    {
        rangeStance = true;
        meleeStance = false;
		magicStance	= false;
    }

	void MagicStance()
	{
		rangeStance = false;
        meleeStance = false;
		magicStance	= true;
        equipmentManager.UnequipAll();
    }

    

    void Attacks()
    {
        if(clickCount == 0)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isAttacking1", false);
            anim.SetBool("isAttacking2", false);
            anim.SetBool("isAttacking3", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJogging", false);
            anim.SetBool("isWalkingBackwards", false);
            anim.SetBool("isJoggingRight", false);
            anim.SetBool("isJoggingleft", false);
        }


        if (meleeStance == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                clickCount += 1;
                Debug.Log("count = " + clickCount);

                if(clickCount == 1)
                {
                    attackCollider.SetActive(true);
                    anim.SetBool("isAttacking1", true);
                    anim.SetBool("isAttacking2", false);
                    anim.SetBool("isAttacking3", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isJogging", false);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isJoggingRight", false);
                    anim.SetBool("isJoggingleft", false);

                    StartCoroutine(Reset());
                }
                else if(clickCount == 2)
                {
                    StopCoroutine(Reset());
                    StartCoroutine(Reset());

                    attackCollider.SetActive(true);
                    anim.SetBool("isAttacking1", true);
                    anim.SetBool("isAttacking2", true);
                    anim.SetBool("isAttacking3", false);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isJogging", false);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isJoggingRight", false);
                    anim.SetBool("isJoggingleft", false);
                }
                else
                {
                    StopCoroutine(Reset());
                    StartCoroutine(Reset());

                    attackCollider.SetActive(true);
                    anim.SetBool("isAttacking1", true);
                    anim.SetBool("isAttacking2", true);
                    anim.SetBool("isAttacking3", true);
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isJogging", false);
                    anim.SetBool("isWalkingBackwards", false);
                    anim.SetBool("isJoggingRight", false);
                    anim.SetBool("isJoggingleft", false);
                }
            }

        }
        
		if(rangeStance == true)
        {
            if (Input.GetButton("Fire1"))
            {
                Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);

                // Add velocity to the arrow
                arrowPrefab.GetComponent<Rigidbody>().velocity = arrowPrefab.transform.forward * 10;
            }
        } 
		
		if(magicStance == true)
		{
			if (Input.GetButton("Fire1"))
			{
				if(usingFire == true)
				{
                    Debug.Log("Burning");
                }

                if (usingIce == true)
                {
                    Debug.Log("Freezing");
                }

                if (usingShock == true)
                {
                    Debug.Log("Shocking");
                }
			}

            if(Input.GetButtonDown("Fire1"))
            {
                if (usingHeal == true)
                {
                    Instantiate(healingRing, transform.position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
                }
            }
                
		}
    }

    private IEnumerator Reset()
    {
        if(clickCount == 1)
        {
            yield return new WaitForSeconds(1.5f);
            clickCount = 0;
        }

        if (clickCount == 2)
        {
            yield return new WaitForSeconds(4);
            clickCount = 0;
        }

        if (clickCount >= 3)
        {
            yield return new WaitForSeconds(6);
            clickCount = 0;
        }
        yield return new WaitForSeconds(6);
        clickCount = 0;
        print("WaitAndPrint " + Time.time);
    }

	void SelectSpells()
	{
		if(Input.GetButtonDown("1"))
		{
			MagicStance();
			usingFire = true;
            equipmentManager.UnequipAll();
			Instantiate(fireBall, RightArmSlot.transform.position, RightArmSlot.transform.rotation, RightArmSlot.transform.parent);
			usingIce = false;
			usingShock = false;
			usingHeal = false;
		}

		if(Input.GetButtonDown("2"))
		{
			MagicStance();
			usingFire = false;
			usingIce = true;
			usingShock = false;
			usingHeal = false;
		}

		if(Input.GetButtonDown("3"))
		{
			MagicStance();
			usingFire = false;
			usingIce = false;
			usingShock = true;
			usingHeal = false;
		}

		if(Input.GetButtonDown("4"))
		{
			MagicStance();
			usingFire = false;
			usingIce = false;
			usingShock = false;
			usingHeal = true;
            equipmentManager.UnequipAll();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            damageDealt = 10f;
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        damageDealt = damageDealt / 100f;
        healthBar.fillAmount -= damageDealt;
    }
}
