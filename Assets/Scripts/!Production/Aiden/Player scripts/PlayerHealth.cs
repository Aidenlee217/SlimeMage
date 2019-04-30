using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public PlayerLevelHolder PLH;

    public GameObject DeathScreen;
    public bool Dead = false;

    public Transform Respawn;

    public Image HealthBar;

    public float OriginalHealth = 100;
    public float MaxHealth = 100;
    public float Health = 100;
    public float ArmourTotalPercent;
    public float OriginalRegenRate = 1;
    public float RegenRate;
    public float Timer;
    public float RegenTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
        MaxHealth = OriginalHealth * PLH.HealthLevel;
        Health = MaxHealth;
        RegenRate = OriginalRegenRate * PLH.HealthLevel;
    }

    public void Leveled()
    {
        MaxHealth = OriginalHealth * PLH.HealthLevel;
    }

    public void Refreshed()
    {
        //Add total armour currently equiped values to armour total value.
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = Health / MaxHealth;
        if (Dead != true)
        {
            if (Health < MaxHealth)
            {
                Timer += Time.deltaTime;
                if (Timer >= RegenTime)
                {
                    Health += RegenRate;
                    Timer = 0;
                }
            }
        }
        if (Health <= 0)
        {
            Dead = true;
            Death();
        }        
    }

    void Death()
    {
        gameObject.transform.position = Respawn.position;
        Health = MaxHealth;
        Dead = false;
        //DeathScreen.SetActive(true);
    }

    //public void Save()
    //{
    //    Saver.SavePlayer(PLH);
    //    Debug.Log("Saved");
    //}

    //public void Load()
    //{
    //    PlayerSaveData data = Saver.LoadPlayer();

    //    PLH.PlayerTotalLevel = data.PlayerTotalLevel;
    //    PLH.HealthLevel = data.HealthLevel;
    //    PLH.MeleeLevel = data.MeleeLevel;
    //    PLH.RangeLevel = data.RangeLevel;
    //    PLH.MageLevel = data.MageLevel;
    //    PLH.HealthXP = data.HealthXP;
    //    PLH.MeleeXP = data.MeleeXP;
    //    PLH.RangeXP = data.RangeXP;
    //    PLH.MagicXP = data.MagicXP;

    //    PLH.playerpos.x = data.position[0];
    //    PLH.playerpos.y = data.position[1];
    //    PLH.playerpos.z = data.position[2];
    //    Debug.Log("Loaded");
    //}
}
