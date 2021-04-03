using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageObject : InteractableObject
{

    public override void Look()
    {
        base.Look();
    }
    public override void Interact()
    {
        print("Take items by " + transform.name);
    }
}

