using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public KeyCode debugTestDialog;

    void Update()
    {
        if (Input.GetKeyDown(debugTestDialog))
            ShowText("Hello, world!", 2);
    }

    public void ShowText(string text, int duration)
    {
        StartCoroutine(TextCoroutine(text, duration));
    }

    IEnumerator TextCoroutine(string text, int duration)
    {
        dialogText.text = text;

        yield return new WaitForSeconds(duration);

        dialogText.text = null;
    }
}
