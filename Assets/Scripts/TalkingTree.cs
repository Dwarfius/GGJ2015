using UnityEngine;
using System.Collections;
using System;

public class TalkingTree : Interactible 
{
    private SpriteRenderer talkingTree;

    public override void Interact(PlayerController player)
    {
        talkingTree.renderer.enabled = true;
    }
}
