using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookButton : MonoBehaviour
{
    private RectMenu _menu;
    private void Start()
    {
        _menu = GetComponentInParent<RectMenu>();
    }
    private void OnMouseDown()
    {
        _menu.Parent.Look();
    }
}
