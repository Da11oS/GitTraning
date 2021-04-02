using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectMenu : MonoBehaviour
{
    public LookButton LookButton;
    public InteractoinButton InteractionButton;
    private Animation EmergensAnimation;
    void Start()
    {
        InteractionButton = GetComponentInChildren<InteractoinButton>();
        LookButton = GetComponentInChildren<LookButton>();
        EmergensAnimation = GetComponent<Animation>();
        EmergensAnimation.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
