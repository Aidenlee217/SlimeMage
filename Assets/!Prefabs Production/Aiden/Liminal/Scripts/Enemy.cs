using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject parent;

    public Animator anim;

    public RuntimeAnimatorController normal;
    public RuntimeAnimatorController glow;

    public GameObject[] players;
    public GameObject Target;
    public float Score = 25;

    public AudioSource Asource;

    public bool Dead = false;

    public bool Glowing = false;

    public Material[] Normal;
    public Material[] Glow;

    public GameObject temp;
    public GameObject Deadblow;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
        Target = players[Random.Range(0, players.Length)];
        gameObject.GetComponent<NavMeshAgent>().destination = Target.transform.position;
        Asource = gameObject.GetComponent<AudioSource>();
    }

    public void Updated()
    {
        if (Glowing == true)
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Glow[Random.Range(0, Glow.Length)];
            Score = Score * 2;
            gameObject.GetComponent<NavMeshAgent>().speed = gameObject.GetComponent<NavMeshAgent>().speed * 2;
            anim.runtimeAnimatorController = glow;

        }
        else
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Normal[Random.Range(0, Normal.Length)];
            anim.runtimeAnimatorController = glow;
        }
    }

    public void Death()
    {
        Asource.Play();
        Dead = true;
        gameObject.GetComponentInChildren<LimAnimations>().Updated();
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        gameObject.GetComponent<NavMeshAgent>().avoidancePriority = 1;
        temp = Instantiate(Deadblow, gameObject.transform.position, Quaternion.identity);
        temp.GetComponent<ParticleSystem>().startColor = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreSystem>().Score += Score;
        yield return new WaitForSeconds(5);
        Destroy(parent);
        yield return true;
    }

    public void Delete()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreSystem>().Score -= Score;
        Destroy(parent);
    }
}
