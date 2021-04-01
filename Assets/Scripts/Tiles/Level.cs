using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Tile> Tiles;
    public Tile CurrentTile;
    static public Level Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        CurrentTile.Enter();
    }

}
