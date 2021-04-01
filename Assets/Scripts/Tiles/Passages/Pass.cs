using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Pass : MonoBehaviour
{
    public Tile PassTo;

    abstract protected void PlayAnimation();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Level.Instance.CurrentTile.IsGoalAchived)
        {
            PassTo.Enter();
            PlayAnimation();
        }
    }
}
