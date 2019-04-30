using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem_E
{

    public static void SavePlayer(TestPlayerScript player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.yalla";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData_E data = new PlayerData_E(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData_E LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.yalla";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData_E data = formatter.Deserialize(stream) as PlayerData_E;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
