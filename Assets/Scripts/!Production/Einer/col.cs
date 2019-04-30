using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour
{
    public int layer1;
    public int layer2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(layer1, layer2, true);
    }
}
