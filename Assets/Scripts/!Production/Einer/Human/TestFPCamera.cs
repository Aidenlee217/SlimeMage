using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFPCamera : MonoBehaviour
{
    Vector3 mouseLook;
    Vector3 smoothV;
    float minY = -60;
    float maxY = 70;
    float minX = -90;
    float maxX = 90;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;
    
    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector3.Scale(md, new Vector3(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.rotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
