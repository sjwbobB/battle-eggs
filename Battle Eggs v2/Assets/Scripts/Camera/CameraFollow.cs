using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objectToFollow;
    public GameObject conversingWith;

    public float moveSpeed;

    public float maxCursorDistance;

    private bool isConversing = false;
    private float initialZ;

    private Vector2 GetCameraPos()
    {
        // Create placeholder Vector3 for modification
        Vector3 vec = objectToFollow.transform.position;

        if (isConversing)
            vec = (vec + conversingWith.transform.position) / 2;

        return vec;
    }

    void Start()
    {
        initialZ = transform.position.z;
    }

    void FixedUpdate()
    {
        // Create placeholder Vector3 for modification
        Vector3 vec = transform.position;

        // Change isConversing if we have an object to converse with
        isConversing = conversingWith != null;

        Vector2 pos = GetCameraPos();

        pos += Vector2.ClampMagnitude(Camera.main.ScreenToViewportPoint(Input.mousePosition), maxCursorDistance);

        // Interpolate vec to the position returned from GetCameraPos() (while keeping z at the initial value)
        vec = Vector3.Lerp(vec, pos, moveSpeed * Time.deltaTime);
        vec.z = initialZ;

        // Set this object's position to vec
        transform.position = vec;
    }
}
