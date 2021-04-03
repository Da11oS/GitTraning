using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractableObject : MonoBehaviour,IObject
{
    public RectMenu MenuPrefab;
    [HideInInspector]
    public Collider2D Collider;
    [SerializeField]
    protected CharacterReaction _reactions;
    public List<AssetItem> Items;
    protected Inventory _invetory => Inventory.Instance;
    private RectMenu _menu;
    protected DialogPanel _dialogPanel;
    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
        _reactions = GetComponent<CharacterReaction>();
    }
    virtual public void Look()
    {
        //Наверное нужно, что - то сказать
        _reactions.Reaction(_reactions.LookingPhrase);
    }
    virtual public void Interact()
    {

        //Наверное нужно, что - то сказать
    }

    private void OnMouseDown()
    {
        _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
        _menu.Parent = this;
        Collider.enabled = false;
    }
}
