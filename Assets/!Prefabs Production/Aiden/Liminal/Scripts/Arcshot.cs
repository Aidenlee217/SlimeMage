using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcshot : MonoBehaviour
{
    public GameObject hit;
    public float speed;
    public float timer;
    public float lifetime;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hit, gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
