using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Saver 
{
    
    public static void SavePlayer (PlayerLevelHolder PLH)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.SD";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSaveData data = new PlayerSaveData(PLH);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSaveData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.SD";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSaveData data = formatter.Deserialize(stream) as PlayerSaveData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
