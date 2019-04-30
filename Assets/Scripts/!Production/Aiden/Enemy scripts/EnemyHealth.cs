using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyHealth : MonoBehaviour {

    public GameObject GM;

    public GameObject Parent;

    public bool CurrentIn = false;
    public bool ActiveSpawn = true;    

    public float Level = 1;
    public float OriginalHealth = 100;
    public float Health;
    public float MaxHealth;
    public Image Healthbar;
    public Text LevelNumber;
    public float Damage;
    public float OriginalDamage = 5;
    public float originalXP;
    public float finalXP;

    public AudioClip Attackaudio;
    public AudioClip Hurtaudio;
    public AudioClip Deathaudio;
    public AudioSource MainSource;

    //public GameObject moving;
    //public GameObject stationary;
    //public GameObject dead;

    public bool AttackPause;

    public bool Walk = false;
    public bool Idle = false;
    public bool Attack = false;
    public bool Death = false;

    private Vector3 point;
    private bool move = false;
    private float timer;
    private bool deads = false;

    public float AttackDistance = 2;

    public float Atime;
    public float ATime = 5f;
    public GameObject AttackColider;
    public Transform SpawnPoint;
    public float xmax;
    public float zmax;
    public Transform target;
    public float Waittime = 1f;
    public float AudioPlayTime = 1;
    public Animations anim;

    public float Mtime;
    public float NextPos = 30;
    public Transform Temptarget;
    public Vector3 temp;

    public bool Agro = false;
    public bool HitAgro = false;
    public float agrotime = 30f;
    public float agrotimer;

    public float Meleedone;
    public float Rangedone;
    public float MagicDone;

	// Use this for initialization
	void Start () {
        GM = GameObject.FindGameObjectWithTag("GM");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = gameObject.GetComponentInChildren<Animations>();
        //anim = gameObject.GetComponent<Animations>();
        //stationary.SetActive(true);
        //moving.SetActive(false);
        //dead.SetActive(false);
        xmax = 0.5f* SpawnPoint.GetComponent<EnemySpawner>().xaxislimit;
        zmax = 0.5f* SpawnPoint.GetComponent<EnemySpawner>().zaxislimit;
        Temptarget.position = SpawnPoint.transform.position;
        gameObject.transform.position = Temptarget.position;
        temp = new Vector3(SpawnPoint.transform.position.x + Random.Range(-xmax, xmax), SpawnPoint.transform.position.y, SpawnPoint.transform.position.z + Random.Range(-zmax, zmax));
        Temptarget.position = temp;
        Leveled();
    }

    public void Leveled()
    {
        Health = Level * OriginalHealth;
        MaxHealth = Health;
        Damage = Level * OriginalDamage;
        LevelNumber.text = ""+Level;
        finalXP = originalXP * Level;
    }
	
	// Update is called once per frame
	void Update () {

        Healthbar.fillAmount = Health / MaxHealth;

        if(HitAgro == true)
        {
            agrotimer += Time.deltaTime;
            Agro = true;
            if(agrotimer>= agrotime)
            {
                HitAgro = false;
                agrotimer = 0;
            }
        }

        Mtime += Time.deltaTime;
        if (Agro == false)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = Temptarget.position;
            if (Mtime >= NextPos)
            {
                temp = new Vector3(SpawnPoint.transform.position.x + Random.Range(-xmax, xmax), 0, SpawnPoint.transform.position.z + Random.Range(-zmax, zmax));
                Temptarget.position = temp;
                Mtime = 0;
            }
        }
        else
        {
            if (AttackPause == false)
            {
                if (Vector3.Distance(gameObject.transform.position, target.position) <= AttackDistance +3)
                {
                    gameObject.transform.LookAt(new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z));
                }
                Atime += Time.deltaTime;
                gameObject.GetComponent<NavMeshAgent>().destination = target.position;
                if (Atime >= ATime)
                {
                    if (Vector3.Distance(gameObject.transform.position, target.position) <= AttackDistance)
                    {
                        StartCoroutine(attack());
                    }
                }
            }
            else
            {
                gameObject.transform.LookAt(new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z));
            }
        }

        //if (target.tag == "Player")
        //{
        //    if (Vector3.Distance(gameObject.transform.position, target.position) <= AttackDistance)
        //    {
        //        Attack = true;
        //        anim.Updated();
        //        StartCoroutine(attack());
        //    }
        //}

        timer += Time.deltaTime;

		if(Health <= 0)
        {
            if (Death != true)
            {
                deads = true;
                gameObject.GetComponent<NavMeshAgent>().speed = 0;
                gameObject.GetComponent<NavMeshAgent>().angularSpeed = 0;
                SpawnPoint.GetComponent<EnemySpawner>().KillCount += 1;
                StartCoroutine(Dead());
            }
        }
        if (AttackPause == false)
        {
            if (timer >= 0.1f)
            {
                if (Vector3.Distance(point, gameObject.transform.position) > 0.05f)
                {
                    point = gameObject.transform.position;
                    move = true;
                    timer = 0;
                }
                else
                {
                    move = false;
                }
            }
            if (deads == false)
            {
                if (move == true)
                {
                    Idle = false;
                    Attack = false;
                    Walk = true;
                    Death = false;
                    anim.Updated();
                    //stationary.SetActive(false);
                    //moving.SetActive(true);
                }
                else
                {
                    Idle = true;
                    Attack = false;
                    Walk = false;
                    Death = false;
                    anim.Updated();
                    //stationary.SetActive(true);
                    //moving.SetActive(false);
                }
            }
        }
    }
    IEnumerator Dead()
    {
        Idle = false;
        Attack = false;
        Walk = false;
        Death = true;
        anim.Updated();
        MainSource.clip = Deathaudio;
        MainSource.Play();
        //stationary.SetActive(false);
        //moving.SetActive(false);
        //dead.SetActive(true);

        GM.GetComponent<PlayerLevelHolder>().MeleeXP += finalXP * (Meleedone / MaxHealth);
        GM.GetComponent<PlayerLevelHolder>().RangeXP += finalXP * (Rangedone / MaxHealth);
        GM.GetComponent<PlayerLevelHolder>().MagicXP += finalXP * (MaxHealth-Meleedone-Rangedone);
        GM.GetComponent<PlayerLevelHolder>().HealthXP += finalXP;
        GM.GetComponent<PlayerLevelHolder>().LevelUpdate();


        yield return new WaitForSeconds(10);
        Destroy(Parent);
        AttackPause = false;
        yield return "Success";
    }
    IEnumerator attack()
    {
        Atime = 0;
        Idle = false;
        Attack = true;
        Walk = false;
        Death = false;
        anim.Updated();
        AttackPause = true;
        yield return new WaitForSeconds(Waittime-AudioPlayTime);
        MainSource.clip = Attackaudio;
        MainSource.Play();
        yield return new WaitForSeconds(AudioPlayTime);
        if (AttackColider.GetComponent<AttackZone>().IN == true)
        {
            AttackColider.GetComponent<AttackZone>().Player.GetComponent<PlayerHealth>().Health -= Damage*(1-AttackColider.GetComponent<AttackZone>().Player.GetComponent<PlayerHealth>().ArmourTotalPercent);
        }
        else
        {

        }
        AttackPause = false;
        Idle = true;
        Attack = false;
        Walk = false;
        Death = false;
        yield return "Success";
    }

    public void Damaged()
    {
        MainSource.clip = Hurtaudio;
        MainSource.Play();
    }

    public void Despawn()
    {
        Destroy(Parent);
    }
}
