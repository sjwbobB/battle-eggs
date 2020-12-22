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

    void Update()
    {
        // Move player left and right
        float leftright = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(0.0f, rigid.velocity.y) + Vector2.right * leftright * moveSpeed;
    }
}
