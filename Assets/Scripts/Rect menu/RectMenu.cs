using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectMenu : MonoBehaviour
{
    public LookButton LookButton;
    public InteractoinButton InteractionButton;
    private Animation EmergensAnimation;
    public InteractableObject Parent;
    public float MaxDistanceToCursor;
    public static RectMenu Instance;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        InteractionButton = GetComponentInChildren<InteractoinButton>();
        LookButton = GetComponentInChildren<LookButton>();
        EmergensAnimation = GetComponent<Animation>();
        EmergensAnimation.Play();
    }

    private void OnMouseExit()
    {
        Destroy(gameObject);
    }
    private void Update()
    {

    }
}
