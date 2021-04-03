using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Lever : InteractableObject
{
    [SerializeField]
    private UnityEvent OnActive;
    [SerializeField]
    private List<GameObject> _targets;
    public override void Look()
    {
        base.Look();
    }
    public override void Interact()
    {
        base.Interact();
        IsActive = !IsActive;
        if(IsActive)
        {
            OnActive?.Invoke();
        }
    }
    public void EnabledObjects()
    {
        foreach(var target in _targets)
        {
            EnabledObject(target);
        }
    }
    public void DesabledObjects()
    {
        foreach (var target in _targets)
        {
            DisabledObject(target);
        }
    }
    private void EnabledObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
        var animation = gameObject.GetComponent<Animation>();
        animation.Play();

    }
    private void DisabledObject(GameObject gameObject)
    {
        var animation = gameObject.GetComponent<Animation>();
        animation.Play();
        gameObject.SetActive(false);
    }
}
