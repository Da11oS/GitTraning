using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassToLeft : Pass
{
    protected override void PlayAnimations()
    {
        print("Animation left");
    }
}
