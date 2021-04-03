using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractObject : InteractableObject
{
    override public void Look()
    {
        base.Look();
    }
    override public void Interact()
    {

        foreach (var item in Items)
        {
            if(_invetory.IsConaineItem(item))
                _invetory.RemoveItem(item);
        }
    }

}
