using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelHolder : MonoBehaviour
{

    public int PlayerTotalLevel = 1;
    public int HealthLevel = 1;
    public int MeleeLevel = 1;
    public int RangeLevel = 1;
    public int MageLevel = 1;
    public float HealthXP;
    public float MeleeXP;
    public float RangeXP;
    public float MagicXP;

    public float[] XPRequired;

    public Vector3 playerpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void LevelUpdate()
    {
        PlayerTotalLevel = (HealthLevel + MeleeLevel + RangeLevel + MageLevel) / 4;
    }

    public void Save()
    {
        Saver.SavePlayer(this);
        Debug.Log("Saved");
    }

    public void Load()
    {
        PlayerSaveData data = Saver.LoadPlayer();

        PlayerTotalLevel = data.PlayerTotalLevel;
        HealthLevel = data.HealthLevel;
        MeleeLevel = data.MeleeLevel;
        RangeLevel = data.RangeLevel;
        MageLevel = data.MageLevel;
        HealthXP = data.HealthXP;
        MeleeXP = data.MeleeXP;
        RangeXP = data.RangeXP;
        MagicXP = data.MagicXP;

        playerpos.x = data.position[0];
        playerpos.y = data.position[1];
        playerpos.z = data.position[2];
        Debug.Log("Loaded");

        GameObject.FindGameObjectWithTag("Player").transform.position = playerpos;

        LevelUpdate();
    }
}
