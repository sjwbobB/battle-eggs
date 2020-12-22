using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    #region "Variables"
    public GameObject objectToFollow;
    public float lerpScale;
    #endregion

    private float initialZ;

    void Start()
    {
        initialZ = transform.position.z;
    }

    void FixedUpdate()
    {
        // Create placeholder Vector3 for modification
        Vector3 vec = transform.position;

        // Interpolate vec to the other object's position (while keeping z at the initial value)
        vec = Vector3.Lerp(vec, objectToFollow.transform.position, lerpScale * Time.deltaTime);
        vec.z = initialZ;

        // Set this object's position to vec
        transform.position = vec;
    }
}
