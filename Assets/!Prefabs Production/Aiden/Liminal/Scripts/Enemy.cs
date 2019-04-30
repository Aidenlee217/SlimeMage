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

    public GameObject Target;
    public float Score = 25;

    public AudioSource Asource;

    public bool Dead = false;

    public bool Glowing = false;

    public Material[] Normal;
    public Material[] Glow;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        Target = GameObject.FindGameObjectWithTag("Player");
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
        StartCoroutine(Remove());
    }

    IEnumerator Remove()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreSystem>().Score += Score;
        yield return new WaitForSeconds(5);
        Destroy(parent);
        yield return true;
    }
}
