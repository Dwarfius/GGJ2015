using UnityEngine;
using System.Collections;

public class Animation2d : MonoBehaviour 
{
    public enum State { Idle, Run, Jump, Fall }
    int stateCount = 4;

    [System.Serializable]
    public class TilesType { public int count; public bool looping; }
    public TilesType[] tilesX;
    public int fps = 10;
    public State state = State.Idle;

	bool goingRight = true;
    Vector2 size;
    int lastIndex = -1;
    float timer;
    int index = 0;
    TilesType currType;

    void Start()
    {
        currType = tilesX[0];
        int max = 0;
        for (int i = 0; i < tilesX.Length; i++)
            max = Mathf.Max(max, tilesX[i].count);

        size = new Vector2(1.0f / max, 1.0f / stateCount);
        renderer.material.SetTextureScale("_MainTex", size);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate index
        timer += Time.deltaTime;
        if (timer > 1 / fps)
        {
            timer = 0;
            if (currType.looping)
                index = ++index % currType.count;
            else if (index < currType.count - 1) //stay on last frame if not looping
                index++;
        }
        
        if(index != lastIndex)
        {
            // split into horizontal and vertical index
            int uIndex = index;
            int vIndex = stateCount - ((int)state + 1);
      
            // build offset
            // v coordinate is the bottom of the image in opengl so we need to invert.
            Vector2 offset = new Vector2 (uIndex * size.x, vIndex * size.y);
            renderer.material.SetTextureOffset("_MainTex", offset);

            lastIndex = index;
        }
    }
	
	public void SetState(State state)
    {
        if (this.state == state)
            return;

        timer = 0;
        index = 0;
        this.state = state;
        Debug.Log(state);
        currType = tilesX[(int)state];
    }
}