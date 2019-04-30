using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerLevelHolder PLH;
    public int playerlevel;

    public int MinSpawnLevel = 1;
    public int MaxSpawnLevel = 2;

    public int SpawnedMin;
    public int SpawnedMax;

    public float xaxislimit = 5;
    public float zaxislimit = 5;

    public GameObject[] Enemies;
    public GameObject[] ActiveEnemies;

    public string Location;
    public string Enemytype;
    public float TotalEnemies;
    public float KillCount;
    public bool AllDead;

    void Start()
    {
        PLH = GameObject.FindGameObjectWithTag("GM").GetComponent<PlayerLevelHolder>();
    }

    

    public void Activate()
    {
        //Preset();
        AllDead = false;
        playerlevel = PLH.PlayerTotalLevel;
        SpawnedMin = playerlevel + MinSpawnLevel;
        SpawnedMax = playerlevel + MaxSpawnLevel;
        for (int i = 0; i < Enemies.Length; ++i)
        {
            if (ActiveEnemies[i] != null)
            {
                //Destroy(ActiveEnemies[i]);
                ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().ActiveSpawn = true;
            }
            else
            {
                ActiveEnemies[i] = Instantiate(Enemies[i], new Vector3((gameObject.transform.position.x+Random.Range(-5, 5)), gameObject.transform.position.y,(gameObject.transform.position.z+Random.Range(-5,5))), Quaternion.identity,gameObject.transform);
                ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().SpawnPoint = gameObject.transform;
                ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().Agro = false;
                ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().Level = Random.Range(SpawnedMin, SpawnedMax);
                ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().ActiveSpawn = true;
                //ActiveEnemies[i].transform.position = gameObject.transform.position;
            }
        }
    }

    void Preset()
    {
        playerlevel = PLH.PlayerTotalLevel;
        SpawnedMin = playerlevel + MinSpawnLevel;
        SpawnedMax = playerlevel + MaxSpawnLevel;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red *0.75f;
        Gizmos.DrawCube(transform.position, new Vector3(xaxislimit, 10, zaxislimit));
        //Gizmos.DrawWireCube(transform.position,new Vector3(xaxislimit,3,zaxislimit));
    }

    public void Deactivate()
    {
        for (int i = 0; i < ActiveEnemies.Length; ++i)
        {
            if (ActiveEnemies[i] != null)
            {
                //ActiveEnemies[i].GetComponent<EnemyHealth>
                if (ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().CurrentIn == false)
                {
                    Debug.Log("SpawnedDeactivate");
                    Destroy(ActiveEnemies[i]);
                }
                else
                {
                    ActiveEnemies[i].GetComponentInChildren<EnemyHealth>().ActiveSpawn = false;
                }
            }
            else
            {

            }
        }
    }

}
