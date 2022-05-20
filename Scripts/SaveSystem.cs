using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGame1 (Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game1.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);
        //PlayerPrefs here?
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame1 () {
        string path = Application.persistentDataPath + "/game1.txt";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGame2 (Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game2.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);
        //PlayerPrefs here?
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame2 () {
        string path = Application.persistentDataPath + "/game2.txt";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveGame3 (Player player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game3.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);
        //PlayerPrefs here?
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame3 () {
        string path = Application.persistentDataPath + "/game3.txt";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
