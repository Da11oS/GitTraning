using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerPass : Pass
{
    protected override void PlayAnimations()
    {
        throw new System.NotImplementedException();
    }
    override protected void SwitchTile(GameObject triger)
    {

        if (ParentTile.PastTile != null)
        {
            ParentTile.PastTile.Enter();
        }
        //SetPlayerPostition
    }
}
