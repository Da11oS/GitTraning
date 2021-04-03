using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IObject
{
    public RectMenu MenuPrefab;
    public Collider2D Collider;
    private RectMenu _menu;
    [TextArea]
    public string Monolog;
    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }
    virtual public void Look()
    {
        print("Look in " + transform.name);
    }
    virtual public void Interact()
    {
        print("Interact whith " + transform.name);
    }


    //private void Update()
    //{
    //    float distance = GetToCursorDistance();
    //    if (distance < 7)
    //    {

    //    }
    //    print(GetToCursorDistance());
    //}
    //private float GetToCursorDistance()
    //{
    //    Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    return Vector2.Distance(MousePosition, transform.position);
    //}
    private void OnMouseDown()
    {
        _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
        _menu.Parent = this;
        Collider.enabled = false;
    }
}
