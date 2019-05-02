using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShots : MonoBehaviour
{
    public GameObject Shot;
    public GameObject tempshot;

    public IEnumerator Shooting()
    {
        tempshot = Instantiate(Shot, new Vector3(gameObject.transform.position.x + (Random.Range(-5, 5)), 10, gameObject.transform.position.z + (Random.Range(-5, 5))),Quaternion.identity);
        tempshot.transform.LookAt(gameObject.transform);
        new WaitForSeconds(1);
        yield return true;
    }
}
