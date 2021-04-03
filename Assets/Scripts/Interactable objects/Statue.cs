using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Statue : Lever
{
    [SerializeField][TextArea]
    private string _LongReaction;
    private Transform RayRanderar;
    override protected void EnableRectMenu()
    {
        //if()
        base.EnableRectMenu();
        //else
        _reactions.Reaction(_LongReaction);
    }
    override public void Interact()
    {
        OnActive?.Invoke();
    }
    private void RayCast()
    {

    }

}
