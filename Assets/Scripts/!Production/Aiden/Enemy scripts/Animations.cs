using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Animations : MonoBehaviour
{
    public bool Idle;
    public bool Walk;
    public bool Attack;
    public bool Death;

    public Animator anim;

    public EnemyHealth EH;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        EH = gameObject.GetComponentInParent<EnemyHealth>();
        //EH = gameObject.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Idle == true)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Death", false);
            Idle = false;
            Walk = false;
            Attack = false;
            Death = false;
        }
        if (Walk == true)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            anim.SetBool("Attack", false);
            anim.SetBool("Death", false);
            Idle = false;
            Walk = false;
            Attack = false;
            Death = false;
        }
        if (Attack == true)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", true);
            anim.SetBool("Death", false);
            Idle = false;
            Walk = false;
            Attack = false;
            Death = false;
            //anim.SetBool("Attack", false);
        }
        if (Death == true)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Death", true);
            Idle = false;
            Walk = false;
            Attack = false;
            Death = false;
        }
    }
    public void Updated()
    {
        Idle = EH.Idle;
        Walk = EH.Walk;
        Attack = EH.Attack;
        Death = EH.Death;
    }
}
