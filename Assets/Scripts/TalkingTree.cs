using UnityEngine;
using System.Collections;
using System;

public class TalkingTree : Interactible 
{
    public override void Interact(PlayerController player)
    {
        renderer.enabled = true;
    }
}
