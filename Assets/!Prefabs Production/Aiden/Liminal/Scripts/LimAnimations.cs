using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LimAnimations : MonoBehaviour
{
    public bool Death;

    public Animator anim;

    public Enemy Enemy;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Enemy = gameObject.GetComponentInParent<Enemy>();
        //EH = gameObject.GetComponent<EnemyHealth>();
        anim.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Death == true)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Death", true);
            Death = false;
        }
    }
    public void Updated()
    {
        Death = Enemy.Dead;
    }
}
