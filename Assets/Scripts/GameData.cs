using UnityEngine;
using System.Collections;

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
}
