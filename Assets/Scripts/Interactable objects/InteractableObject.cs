using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IObject
{
    public RectMenu MenuPrefab;
    [HideInInspector]
    public Collider2D Collider;
    [TextArea]
    public List<string> TakingPhrases;
    [TextArea]
    public List<string> LookingPhrases;
    public List<AssetItem> Items;
    protected Inventory _invetory => Inventory.Instance;
    private RectMenu _menu;
    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }
    virtual public void Look()
    {
        ////�������� �����, ��� - �� �������
    }
    virtual public void Interact()
    {

        //�������� �����, ��� - �� �������
    }


    private void OnMouseDown()
    {
        _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
        _menu.Parent = this;
        Collider.enabled = false;
    }
}
