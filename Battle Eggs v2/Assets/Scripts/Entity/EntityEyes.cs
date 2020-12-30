using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEyes : MonoBehaviour
{
    public new SpriteRenderer renderer;
    public float moveSpeed;

    private Vector3 initialPosition;

    void Awake()
    {
        initialPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        // Create placeholder Vector3 for modification
        Vector3 vec = initialPosition;

        // Invert x if player's renderer is flipped
        vec.x *= (renderer.flipX ? 1.0f : -1.0f);

        transform.localPosition = Vector3.Lerp(transform.localPosition, vec, moveSpeed * Time.deltaTime);
    }
}
