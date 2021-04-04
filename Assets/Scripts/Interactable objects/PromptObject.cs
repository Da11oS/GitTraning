using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptObject : InteractableObject
{
    [SerializeField]
    private InteractableObject _targetObject;
    protected override void EnableRectMenu()
    {
        if (_targetObject.IsActive)
        {
            Destroy(this);

        }
        else
        {
            base.EnableRectMenu();
            _menu.InteractionButton.gameObject.SetActive(false);
        }
    }
    override public void Interact()
    {
        _reactions.Reaction(_reactions.InteractionPhrase);
    }
}
