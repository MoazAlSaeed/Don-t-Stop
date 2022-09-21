using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//need to be studied more
public static class SaveSystem 
{

    public static void SavePlayer(playerMovement player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/highScore.wowNoob";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerData data = new PlayerData(player);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData loadScore()
    {
          string path = Application.persistentDataPath + "/highScore.wowNoob";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =  new FileStream(path,FileMode.Open);
          PlayerData data =   formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save File not Load in "+path);
            return null;
        }
    }

}
