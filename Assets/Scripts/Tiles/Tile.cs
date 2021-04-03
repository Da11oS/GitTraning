using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector]
    public Pass Exit;
    [HideInInspector]
    public InnerPass Entrance;
    public Tile NextTile;
    public Tile PastTile;
    public TilePulls Pull;
    [HideInInspector]
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
        Level.Instance.CurrentTile = this;
        StartCoroutine(SetCameraPosition());
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
    private IEnumerator SetCameraPosition()
    {
        int i = 0;
        do
        { 
            i++;
            yield return new WaitForSeconds(1f);
        } while (i < 0);
        print("Switch pos");
        Level.Instance.SetCameraPosition();

    }

}
