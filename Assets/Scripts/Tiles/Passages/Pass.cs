using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Pass : MonoBehaviour
{
    protected Tile ParentTile;

    abstract protected void PlayAnimations();
    public void Start()
    {
        ParentTile = GetComponentInParent<Tile>();
    }
    //public void Update()
    //{
    //    if (Level.Instance.CurrentTile.IsGoalAchived )
    //    {
    //        if(Level.Instance.CurrentTile.NextTile == null)
    //        {
    //            Level.Instance.Instantiate();
    //        }

    //        Level.Instance.CurrentTile.IsGoalAchived = false;
    //    }
    //    isGoalAchivedInLasFrame = Level.Instance.CurrentTile.IsGoalAchived;
    //}
    public void OnMouseDown()
    {
        SwitchTile(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && ParentTile.IsGoalAchived)
        {
            SwitchTile(collision.gameObject);
        }
    }
    abstract protected void SwitchTile(GameObject triger);

}
