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
        if (Inventory.Instance != null)
        {
            Inventory.Instance.gameObject.SetActive(true);
        }
        EmergensAnimation.Play();
        FexedPosition();
    }

    private void Update()
    {
        if (GetToCursorDistance() > 5)
            Destroy(gameObject);

    }
    private void OnDestroy()
    {
        Parent.Collider.enabled = true;
        if(Inventory.Instance != null)
            Inventory.Instance.gameObject.SetActive(false);
    }
    private float GetToCursorDistance()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Vector2.Distance(MousePosition, transform.position);
    }
    private void FexedPosition()
    {
        Vector2 cameraPosition = FindObjectOfType<Camera>().transform.position;
        Vector2 directionToCamera = cameraPosition - (Vector2)transform.position;
        directionToCamera /= directionToCamera.magnitude;
        transform.position += (Vector3)directionToCamera * 3;

    }
}
