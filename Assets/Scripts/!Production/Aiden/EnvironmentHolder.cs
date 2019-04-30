using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHolder : MonoBehaviour
{
    public GameObject Trees;

    public void Activate()
    {
        Trees.SetActive(true);
    }

    public void Deactivate()
    {
        Trees.SetActive(false);
    }
}
