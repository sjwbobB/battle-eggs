using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// I'm planning to rewrite this from scratch because this is a mess
public class HUDPlayerPanel : MonoBehaviour
{
    public AudioClip clip;

    public RectTransform rectTransform;

    public float initialPosition;
    public float expandedPosition;
    public float initialY;
    
    private bool expanded = false;

    private Vector2 targetPosition;

    private int width, height;

    void Awake()
    {
        width = Screen.width;
        height = Screen.height;
        transform.position = new Vector2(initialPosition * width, initialY * height);
    }

    void Update()
    {
        RectTransform parentTransform = GetComponentInParent<RectTransform>();

        rectTransform.rect.Set(0.0f, 0.0f, rectTransform.rect.width, parentTransform.rect.height);
        transform.position = Vector2.Lerp(transform.position, targetPosition, 16.0f * Time.deltaTime);
    }

    public void Toggle()
    {
        expanded = !expanded;
        AudioSource.PlayClipAtPoint(clip, Vector2.zero);

        targetPosition = new Vector2((expanded ? expandedPosition : initialPosition) * width, initialY * height);
    }
}
