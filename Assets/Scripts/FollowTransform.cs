using UnityEngine;
using System.Collections;

public class FollowTransform : MonoBehaviour 
{
    public Transform target;

    void Update () 
    {
        Vector3 pos = target.position;
        pos.z = -10;
        transform.position = pos;
	}
}
