using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{

    public int PlayerTotalLevel;
    public int HealthLevel;
    public int MeleeLevel;
    public int RangeLevel;
    public int MageLevel;
    public float HealthXP;
    public float MeleeXP;
    public float RangeXP;
    public float MagicXP;

    public float[] position;

    public PlayerSaveData(PlayerLevelHolder PLH)
    {
        PlayerTotalLevel = PLH.PlayerTotalLevel;
        HealthLevel = PLH.HealthLevel;
        MeleeLevel = PLH.MeleeLevel;
        RangeLevel = PLH.RangeLevel;
        MageLevel = PLH.MageLevel;
        HealthXP = PLH.HealthXP;
        MeleeXP = PLH.MeleeXP;
        RangeXP = PLH.RangeXP;
        MagicXP = PLH.MagicXP;

        position = new float[3];
        position[0] = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        position[1] = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        position[2] = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        //position[0] = PLH.playerpos.x;
        //position[1] = PLH.playerpos.y;
        //position[2] = PLH.playerpos.z;
    }

}
