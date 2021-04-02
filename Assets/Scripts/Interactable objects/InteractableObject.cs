using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IObject
{
    public RectMenu MenuPrefab;
    
    private RectMenu _menu;
    [TextArea]
    public string Monolog;
    virtual public void Look()
    {
        print("Look in " + transform.name);
    }
    virtual public void Interact()
    {
        print("Interact whith " + transform.name);
    }


    private void Update()
    {
        Vector2 mousePosition = Vector3.zero;
        Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(toMouse, out hit))
        {
            if (hit.collider.GetComponent<InteractableObject>() != null)
            {
                mousePosition = transform.InverseTransformPoint(hit.point);
                _menu = Instantiate(MenuPrefab, transform.position, MenuPrefab.transform.rotation);
                _menu.Parent = this;
                return;
            }
        }

        if (_menu != null)
        {
            Destroy(_menu.gameObject);
        }

    }
}
