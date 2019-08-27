using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("SaveFile not found");
            return null;
        }
    }

    public static void SavePlayer(Camera camera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path,FileMode.Create);

        CameraData data = new CameraData(camera);

        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static CameraData LoadCamera()
    {
        string path = Application.persistentDataPath + "/camera.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            CameraData data = formatter.Deserialize(stream) as CameraData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("SaveFile not found");
            return null;
        }
    }

}
