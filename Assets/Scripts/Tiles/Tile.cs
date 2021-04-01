using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Pass> Passages;
    public bool IsGoalAchived;
    public void Enter()
    {
        FindObjectOfType<Camera>().transform.position = transform.position;
        Level.Instance.CurrentTile = this;
    }
    public void Exit()
    {

    }
}
