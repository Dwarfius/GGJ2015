using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VIllageFoodMission : MonoBehaviour {

    public Canvas canvas;
    public Text text;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0; //pause
        canvas.enabled = true; //show menu
    }


    public void ButtonPressed(int btnNum)
    {
        switch (btnNum)
        {
            case 0:
                Application.LoadLevel("Flying Donkeys");
                break;
            case 1:
                Application.LoadLevel("VillageFood");
                break;
            case 2:
                Application.LoadLevel("PARTY!");
                break;
        }
    }
}
