using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CharacterReaction))]
public class InteractableObject : MonoBehaviour,IObject
{
    public RectMenu MenuPrefab;
    [HideInInspector]
    public Collider2D Collider;
    public List<AssetItem> Items;
    public bool IsActive;
    protected CharacterReaction _reactions;
    protected Inventory _invetory => Inventory.Instance;
    protected DialogPanel _dialogPanel;
    protected Hero _hero;
    [SerializeField]
    protected float toPlayerDistanceLimit;
    protected RaycastHit2D _ray;
    private RectMenu _menu;
    protected int _layerMask;

    private void Awake()
    {
        _layerMask = 1 << gameObject.layer;
        _layerMask = ~_layerMask;
        Collider = GetComponent<Collider2D>();
        _reactions = GetComponent<CharacterReaction>();
        _hero = FindObjectOfType<Hero>();
    }
    virtual public void Look()
    {
        //�������� �����, ��� - �� �������
       // _reactions.Reaction(_reactions.LookingPhrase);
    }
    virtual public void Interact()
    {

        //�������� �����, ��� - �� �������
    }

    protected void OnMouseDown()
    {
        _ray = GetToPlayerPlayerRaycast();
        if (IsOnPlayer() && _ray.distance < toPlayerDistanceLimit)
        {
            EnableRectMenu();
        }
        else
        {
            _reactions.Reaction("�� ����. ������� ������ " + Vector2.Distance(_hero.transform.position, transform.position));
        }
    }
    virtual protected void EnableRectMenu()
    {

        _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
        _menu.Parent = this;
        Collider.enabled = false;
    }
    protected bool IsOnPlayer()
    {
        return IsNeedLayer(_ray, _hero.gameObject.layer);
    }
    private RaycastHit2D GetToPlayerPlayerRaycast()
    {

        var heading = _hero.transform.position - transform.position;
        var toPlyerDistance = Vector2.Distance(_hero.transform.position, transform.position);
        var toPlayerDirection = heading / heading.magnitude;
        Debug.DrawRay(transform.position, toPlyerDistance * toPlayerDirection, Color.red);
        return Physics2D.Raycast(transform.position, toPlayerDirection, toPlyerDistance, _layerMask);
    }
    private bool IsNeedLayer(RaycastHit2D raycast, int layer)
    {
        return raycast.collider.gameObject.layer == layer;
    }

}
