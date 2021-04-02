using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Pass Exit;
    public InnerPass Entrance;
    public Tile NextTile;
    public Tile PastTile;
    public TilePulls Pull;
    public Borders Borders;
    public bool IsGoalAchived;
    public int ID;

    private void Awake()
    {
        Borders = GetComponentInChildren<Borders>();
        Entrance = GetComponentInChildren<InnerPass>();
        Exit = GetComponentInChildren<Pass>();
    }
    public void Start()
    {
        print("Player.Transform.position = Entrance.transform.position");
    }
    public void Enter()
    {
        Level.Instance.ToBlackout();
        Level.Instance.SetCameraPosition(this);
    }
    public void SetPastTile(Tile tile)
    {
        PastTile = tile;
    }
    public void SetNextTile(Tile tile)
    {
        NextTile = tile;
    }
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

}
