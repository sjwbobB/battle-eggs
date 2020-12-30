using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    public RectTransform upperBar;
    public RectTransform lowerBar;

    public float moveSpeed;

    public KeyCode debugToggleKey;

    private float upperTarget, lowerTarget;
    private bool active = false;

    public void ToggleBars()
    {
        active = !active;

        upperTarget = upperBar.rect.height / 2 * (active ? -1.0f : 1.0f);
        lowerTarget = lowerBar.rect.height / 2 * (active ? -1.0f : 1.0f);
    }

    void Awake()
    {
        upperTarget = upperBar.rect.height / 2;
        lowerTarget = lowerBar.rect.height / 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(debugToggleKey))
            ToggleBars();

        upperBar.anchoredPosition = Vector2.Lerp(upperBar.anchoredPosition, Vector2.up * upperTarget, moveSpeed * Time.deltaTime);
        lowerBar.anchoredPosition = Vector2.Lerp(lowerBar.anchoredPosition, Vector2.down * lowerTarget, moveSpeed * Time.deltaTime);
    }
}
