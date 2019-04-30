using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColTester : MonoBehaviour {

    public int layer1;
    public int layer2;

    void Update()
    {
        Physics.IgnoreLayerCollision(layer1, layer2,true);
    }

}
