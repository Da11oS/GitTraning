using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractObject : InteractableObject
{
    public bool IsWorking;
    override public void Look()
    {
        base.Look();
    }
    override public void Interact()
    {
        bool isInteracted = true;
        foreach (var item in Items)
        {
            if (_invetory.IsConaineItem(item))
                _invetory.RemoveItem(item);
            else
            {
                isInteracted = false;
                _reactions.Reaction(_reactions.NonInteractionPhrase);
            }
        }
        IsWorking = isInteracted;
    }

}
