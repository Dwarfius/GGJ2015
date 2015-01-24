using UnityEngine;
using System.Collections;

public class Item : Interactible 
{
    public string name;

    public override void Interact(PlayerController player)
    {
        player.items.Add(name);
        Destroy(gameObject);
    }
}
