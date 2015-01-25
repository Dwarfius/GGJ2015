using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextureAnimationScript : MonoBehaviour 
{	
	//vars for the whole sheet
	public int colCount =  7;
	public int rowCount =  1;
	
	//vars for animation
    public int rowNumber;
    public int colNumber;
	public int totalCells = 7;
	public int fps = 4;

    public UnityEvent OnFinish;

	[HideInInspector] public bool open, close;
    [HideInInspector] public bool isOpen;

	float timePassed = 0;
    Material mat;

    void Start()
    {
        mat = GetComponent<Image>().material;
        mat.SetTextureScale("_MainTex", Vector2.zero);
    }

	void Update () 
    { 
		if(open)
			SetSpriteAnimation(colCount,rowCount,rowNumber,colNumber,totalCells,fps);
		if(close)
			SetSpriteAnimation(colCount,rowCount,rowNumber,colNumber,totalCells,fps);
	}
	
	void SetSpriteAnimation(int colCount, int rowCount, int rowNumber, int colNumber, int totalCells, int fps)
    {
		timePassed += Time.deltaTime;
		int index  = (int)(timePassed * fps);

		if(index>=totalCells)
		{
            isOpen = !isOpen;
            open = close = false;
            if (OnFinish != null)
                OnFinish.Invoke();
			return;
		}

        if (close)
            index = totalCells - index - 1;

		// Size of every cell
		float sizeX = 1.0f / colCount;
		float sizeY = 1.0f / rowCount;
		Vector2 size =  new Vector2(sizeX,sizeY);
		
		// split into horizontal and vertical index
		var uIndex = index % colCount;
		var vIndex = index / colCount;
		
		// build offset
		// v coordinate is the bottom of the image in opengl so we need to invert.
		float offsetX = (uIndex+colNumber) * size.x;
		float offsetY = (1.0f - size.y) - (vIndex + rowNumber) * size.y;
		Vector2 offset = new Vector2(offsetX,offsetY);
		
		mat.SetTextureOffset ("_MainTex", offset);
		mat.SetTextureScale  ("_MainTex", size);
	}

	public void Reset()
	{
        if (open || close)
            return;
        
		timePassed = 0;
		if(!isOpen)
			open = true;
		else
			close = true;
	}
}
