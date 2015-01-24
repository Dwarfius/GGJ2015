using UnityEngine;
using System.Collections;
using System.IO;

public class GameData : MonoBehaviour {
    static GameData instance;
    public static GameData Instance
    {
        get 
        {
            if(instance == null)
            {
                GameObject obj = new GameObject("Answers");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<GameData>();
            }
            return instance;
        }
    }

    public int[] allAnswers = new int[10];
    float gameTime = 0;

    public void Save(string name)
    {
        string buffer = (gameTime + Time.time).ToString();
        for (int i = 0; i < allAnswers.Length; i++)
            buffer += "\n" + allAnswers[i];

        StreamWriter stream = File.CreateText(name);
        stream.Write(buffer);
        stream.Close();
    }

    public void Load(string name)
    {
        StreamReader stream = File.OpenText(name);
        gameTime = float.Parse(stream.ReadLine());

        int i = 0;
        while(!stream.EndOfStream)
            allAnswers[i++] = int.Parse(stream.ReadLine());
        stream.Close();
    }
}
