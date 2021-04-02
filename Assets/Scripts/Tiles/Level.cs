using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Tile CurrentTile;
    public TilesGenerator Generator;
    [HideInInspector]
    public Animation BlackoutAnimation;
    static public Level Instance;
    public static int TileCount;
    private Camera _camera;
    public int MaxTileCount;
    [SerializeField]
    private GameObject _blackoutPanel;
    public void Awake()
    {
        BlackoutAnimation = _blackoutPanel.GetComponent<Animation>();
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        _camera = FindObjectOfType<Camera>();
    }
    void Start()
    {
        TileCount = 1;


        //Player.Transform.position = CurrentTile.InnerPass.transform.position;
    }
    public void ToBlackout()
    {
        BlackoutAnimation.Play();
    }
    public void Instantiate()
    {


        if (TileCount < MaxTileCount)
        {
            TileCount++;
            Generator.SetNewTile(CurrentTile);
        }
        else
        {
            Generator.SetFinish();
        }
        CurrentTile.Enter();
    }
    public void SetCameraPosition(Tile tile)
    {
        _camera.transform.position = tile.transform.position;
    }
}
