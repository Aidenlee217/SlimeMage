using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public Transform UISpawn;

    public GameObject PlayerCam;

    public GameObject Menu;
    public GameObject Inventory;

    public bool Active = false;

	// Use this for initialization
	void Start () {
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
    }

    // Update is called once per frame
    void Update () {
        UISpawn.LookAt(PlayerCam.transform);

        if (Active == false)
        {
            if (OVRInput.Get(OVRInput.Button.Start) == true)
            {
                Active = true;
                StartCoroutine(MainMenu());
            }

            if (OVRInput.Get(OVRInput.Button.One) == true)
            {
                Active = true;
                StartCoroutine(VRInventory());
            }
        }
	}

    IEnumerator MainMenu()
    {
        Menu.SetActive(!Menu.activeSelf);
        Menu.transform.position = UISpawn.transform.position;
        Menu.transform.rotation = UISpawn.transform.rotation;
        yield return new WaitForSeconds(0.5f);
        Active = false;
        yield return true;
    }

    IEnumerator VRInventory()
    {
        Inventory.SetActive(!Inventory.activeSelf);
        Inventory.transform.position = UISpawn.transform.position;
        Inventory.transform.rotation = UISpawn.transform.rotation;
        yield return new WaitForSeconds(0.5f);
        Active = false;
        yield return true;
    }
}
