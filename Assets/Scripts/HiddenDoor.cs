using UnityEngine;
using System.Collections;

public class HiddenDoor : Interactible {

    public override void Interact(PlayerController player)
    {
        Application.LoadLevel("TestScene");
    }
}
