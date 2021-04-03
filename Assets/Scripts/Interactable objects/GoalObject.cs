using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : InteractableObject
{
    [SerializeField]
    private ItemInteractObject _activator;

    override public void Look()
    {
        base.Look();
    }
    override public void Interact()
    {
        if(_activator.IsWorking)
        {
            Level.Instance.CurrentTile.IsGoalAchived = true;
        }
        else
        {
            _reactions.Reaction(_reactions.NonInteractionPhrase);
        }
    }
}
