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
    [SerializeField]
    protected CharacterReaction _reactions;
    protected Inventory _invetory => Inventory.Instance;
    protected DialogPanel _dialogPanel;
    private RectMenu _menu;
    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
        _reactions = GetComponent<CharacterReaction>();
    }
    virtual public void Look()
    {
        //Наверное нужно, что - то сказать
       // _reactions.Reaction(_reactions.LookingPhrase);
    }
    virtual public void Interact()
    {

        //Наверное нужно, что - то сказать
    }

    protected void OnMouseDown()
    {
        EnableRectMenu();
    }
    virtual protected void EnableRectMenu()
    {
        _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
        _menu.Parent = this;
        Collider.enabled = false;
    }
}
