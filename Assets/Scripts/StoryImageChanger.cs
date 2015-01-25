using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryImageChanger : MonoBehaviour 
{
    public Button btn;
    public Image image;
    public Sprite img2, img3;
    public GameObject writersOwner;

    int state = 0;
    GenericWriteoutScript[] writers;

    void Start()
    {
        writers = writersOwner.GetComponents<GenericWriteoutScript>();
    }

    public void NextState()
    {
        btn.gameObject.SetActive(false);
        state++;
        if (state == 3)
            Application.LoadLevel("Main");
        image.sprite = state == 1 ? img2 : img3;
        writers[1].enabled = state == 1;
        writers[2].enabled = state == 2;
        
    }
}
