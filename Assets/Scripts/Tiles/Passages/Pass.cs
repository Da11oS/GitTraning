using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Pass : MonoBehaviour
{
    public TilePulls Pull;
    public Tile NextTile;
    private Tile ParentTile;
    private bool isGoalAchivedInLasFrame;
    abstract protected void PlayAnimations();
    public void Start()
    {
        isGoalAchivedInLasFrame = Level.Instance.CurrentTile.IsGoalAchived;
        ParentTile = GetComponentInParent<Tile>();
    }
    public void Update()
    {
        if (Level.Instance.CurrentTile.IsGoalAchived )
        {
            if(Level.Instance.CurrentTile.NextTile == null)
            {
                Level.Instance.Instantiate();
            }

            Level.Instance.CurrentTile.IsGoalAchived = false;
        }
        isGoalAchivedInLasFrame = Level.Instance.CurrentTile.IsGoalAchived;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Level.Instance.CurrentTile.IsGoalAchived)
        {
            if (Level.Instance.CurrentTile.NextTile == null)
            {
                Level.Instance.Instantiate();
            }

        }
    }
}
