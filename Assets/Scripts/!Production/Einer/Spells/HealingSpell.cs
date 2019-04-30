using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpell : MonoBehaviour {

    public GameObject player;
    public ParticleSystem PS;
    public PlayerScript playerScript;
    public float healAmount = .0005f;
    public float activeTime = 7;
    
    // Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        PS = gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(Destroy());
	}

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerScript.healthBar.fillAmount += healAmount;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(activeTime);
        PS.Stop();
        yield return new WaitForSeconds(4);
        Destroy(gameObject);

    }
}
