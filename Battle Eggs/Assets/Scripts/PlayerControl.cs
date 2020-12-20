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
        // Setup Rigidbody 2D
        rigid.freezeRotation = true;
    }

    void Update()
    {
        // Move player left and right
        float leftright = Input.GetAxisRaw("Horizontal");
        rigid.MovePosition(new Vector2(leftright * moveSpeed * Time.deltaTime, 0.0f));
    }
}
