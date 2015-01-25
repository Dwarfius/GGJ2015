using UnityEngine;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour 
{
    public enum State { Main, Options, Load }
    State state = State.Main;
    string[] saves = new string[5]; 

    void Start()
    {
        for(int i=0; i<5; i++)
        {
            if (File.Exists("Save " + i + ".sv"))
            {
                StreamReader stream = File.OpenText("Save " + i + ".sv");
                float time = float.Parse(stream.ReadLine());
                stream.Close();
                
                int h = 0, m = 0, s = 0;
                if(time > 60 * 60)
                {
                    h = (int)(time / 3600);
                    time -= h * 3600;
                }
                if(time > 60)
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

    void OnGUI()
    {
        int x = Screen.width / 2, y = Screen.height / 4;
        int width = Screen.width / 10, height = Screen.height / 12;
        int space = Screen.height / 20;

if(state == State.Load)
        {
            GUI.Box(new Rect(x - width / 2, y, width, height), "Load");
            y += height + space;
            
            for(int i=0; i<5; i++)
            {
                if(saves[i] != null)
                {
                    if(GUI.Button(new Rect(x - width / 2, y, width, height), saves[i]))
                    {
                        GameData.Instance.Load("Save " + i + ".sv");
                        Application.LoadLevel(1);
                    }
                    y += height + space;
                }
            }

            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Back"))
                state = State.Main;
        }
        else if(state == State.Options)
        {
            if (GUI.Button(new Rect(x - width / 2, y, width, height), "Back"))
                state = State.Main;
        }
    }

    void LoadLevel1()
    {
        Application.LoadLevel("Tutorial");
    }

    void Exit()
    {
        Application.Quit();
    }
}
