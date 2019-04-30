using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {

    public static GameSaveManager instance;

    //public Keybindings keybindings;

    public VRInventory inventory;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LoadGame();
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/Game_Save");
    }

    public void SaveGame()
    {
        #region Game_Save
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save");
        }
        #endregion
        #region Save_Inventory
        if (!Directory.Exists(Application.persistentDataPath + "/Game_Save/Inventory_Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save/Inventory_Data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Game_Save/Inventory_Data/Inventory_Save.txt");
        var json = JsonUtility.ToJson(inventory);
        bf.Serialize(file, json);
        file.Close();
        #endregion
    }

    public void LoadGame()
    {
        #region Load_Inventory
        if (!Directory.Exists(Application.persistentDataPath + "/Game_Save/Inventory_Data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Game_Save/Inventory_Data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "/Game_Save/Inventory_Data/Inventory_Save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/Game_Save/Inventory_Data/Inventory_Save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), inventory);
            file.Close();
        }
        #endregion
    }
}
