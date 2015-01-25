using UnityEngine;
using System.Collections;

public class CameraFollowPlayerScript : MonoBehaviour 
{
	public GameObject target;
	public Vector3 offset;

	private void Update()
	{
		if (!target)
			return;
	
		Vector3 wantedPos = (target.transform.position + offset);
		wantedPos.y = offset.y;
		transform.position = Vector3.Lerp(transform.position, wantedPos, Time.deltaTime * 5);
	}
}