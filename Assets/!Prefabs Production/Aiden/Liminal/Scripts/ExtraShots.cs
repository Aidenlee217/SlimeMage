using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShots : MonoBehaviour
{
    public GameObject Shot;
    public GameObject tempshot;
    public float number= 0;
    public float total = 3;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    public IEnumerator Shooting()
    {
        while (number < total)
        {
            tempshot = Instantiate(Shot, new Vector3(gameObject.transform.position.x + (Random.Range(-5, 5)), 10, gameObject.transform.position.z + (Random.Range(-5, 5))), Quaternion.identity);
            tempshot.transform.LookAt(gameObject.transform);
            yield return new WaitForSeconds(1);
            number += 1;
        }
        yield return true;
    }
}
