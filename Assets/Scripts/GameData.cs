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
    float timeStarted = 0; //used not to count time spent in main menu
    float gameTime = 0;

    public void Save(string name)
    {
        string buffer = (gameTime + (Time.time - timeStarted)).ToString();
        for (int i = 0; i < allAnswers.Length; i++)
            buffer += "\n" + allAnswers[i];

        StreamWriter stream = File.CreateText(name);
        stream.Write(buffer);
        stream.Close();
        CheckSaves();
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

    void Start()
    {
        timeStarted = Time.time;
    }

    enum State { Game, Menu, Save }
    State state = State.Game;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            state = state == State.Game ? State.Menu : state == State.Save ? State.Menu : State.Game;

        Time.timeScale = state == State.Game ? 1 : 0;
    }

    void OnGUI()
    {
        int x = Screen.width / 2, y = Screen.height / 8;
        int width = Screen.width / 10, height = Screen.height / 16;
        int space = Screen.height / 20;

        if(state == State.Menu)
        {
            GUI.Box(new Rect(x - width / 2, y, width, height), "Pause");
            y += height + space;

            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Continue"))
                state = State.Game;
            y += height + space;

            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Save"))
                state = State.Save;
            y += height + space;

            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Quit"))
                Application.LoadLevel(0);
        }
        else if(state == State.Save)
        {
            GUI.Box(new Rect(x - width / 2, y, width, height), "Save Game");
            y += height + space;

            for (int i = 0; i < 5; i++)
            {
                string s = saves[i] != null ? saves[i] : "Save Slot " + i;
                if (GUI.Button(new Rect(x - width / 2, y, width, height), s))
                    GameData.Instance.Save("Save " + i + ".sv");
                y += height + space;
            }

            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Back"))
                state = State.Menu;
        }
    }

    string[] saves = new string[5];
    void CheckSaves()
    {
        for(int i=0; i<saves.Length; i++)
        {
            if (File.Exists("Save " + i + ".sv"))
            {
                StreamReader stream = File.OpenText("Save " + i + ".sv");
                float time = float.Parse(stream.ReadLine());
                stream.Close();

                int h = 0, m = 0, s = 0;
                if (time > 60 * 60)
                {
                    h = (int)(time / 3600);
                    time -= h * 3600;
                }
                if (time > 60)
                {
                    m = (int)(time / 60);
                    time -= m * 60;
                }
                s = (int)time;
                
                saves[i] = string.Format("Save {0} - Time: {1}h {2}m {3}s", i + 1, h, m, s);
            }
            else
                saves[i] = null;
        }
    }
}
