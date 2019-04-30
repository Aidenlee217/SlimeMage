using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public TestPlayerScript player;
    PlayerHealth healthScript;

    public void Start()
    {
        player = FindObjectOfType<TestPlayerScript>();
    }


    public void NewGameButton (string NewGameLevel)
    {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void SaveGameButton()
    {
        SaveSystem_E.SavePlayer(player);
    }

    public void LoadGameButton()
    {
        PlayerData_E data = SaveSystem_E.LoadPlayer();

        healthScript.Health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

}
