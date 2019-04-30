using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLoader : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Environment")
        {
            other.gameObject.GetComponent<EnvironmentHolder>().Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            other.gameObject.GetComponent<EnvironmentHolder>().Deactivate();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red * 0.75f;
        //Gizmos.DrawCube(transform.position, new Vector3(xaxislimit, 3, zaxislimit));
        //Gizmos.DrawWireCube(transform.position,new Vector3(xaxislimit,3,zaxislimit));
    }

}
