using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour 
{
    public UnityEvent EnteredTrigger;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && EnteredTrigger != null)
            EnteredTrigger.Invoke();
    }
}
