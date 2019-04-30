using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectActive : MonoBehaviour
{
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        active = false;
        gameObject.GetComponentInParent<ActiveSlots>().CurrentActiveSlot = null;
    }

    public void Pressed()
    {
        if (active == false)
        {
            gameObject.GetComponentInParent<SingleSelectInventory>().Run();
            active = true;
            gameObject.GetComponent<Image>().color = Color.green;
            gameObject.GetComponentInParent<ActiveSlots>().CurrentActiveSlot = gameObject;
        }
        else
        {
            Reset();
        }
    }
}
