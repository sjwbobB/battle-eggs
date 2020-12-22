using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region "Variables"
    public Rigidbody2D rigid;
    public float moveSpeed;
    #endregion

    void Start()
    {
    }

    void LateUpdate()
    {
        // Move player left and right
        float leftright = Input.GetAxisRaw("Horizontal");
        rigid.velocity = Vector2.right * leftright * moveSpeed;
    }
}
