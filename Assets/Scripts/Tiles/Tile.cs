using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Pass> Passages;
    public Borders Borders;
    public bool IsGoalAchived;
    private void Awake()
    {
        GetComponentInChildren<Borders>();
    }
    public void Enter()
    {
        FindObjectOfType<Camera>().transform.position = transform.position;
        Level.Instance.CurrentTile = this;
    }
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
