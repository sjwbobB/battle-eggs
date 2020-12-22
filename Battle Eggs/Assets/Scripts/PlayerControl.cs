using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region "Variables"
    public Rigidbody2D rigid;
    public new BoxCollider2D collider;
    public float moveSpeed;
    public float jumpPower;
    public float minimalDistanceToGround;
    #endregion

    void Update()
    {
        // Get player inputs
        float leftright = Input.GetAxisRaw("Horizontal");
        bool jumping = Input.GetAxisRaw("Jump") == 1.0f; // jumping = is the "Jump" axis equal to 1? (true/false)

        // Move player left and right
        rigid.velocity = new Vector2(0.0f, rigid.velocity.y) + Vector2.right * leftright * moveSpeed;

        if (jumping)
        {
            // Cast a ray under the player's box collider
            RaycastHit2D hit = Physics2D.Raycast(rigid.position + Vector2.down * (collider.size.y + minimalDistanceToGround), Vector2.down);

            if (hit.distance < minimalDistanceToGround)
            {
                /* 
                 * Launch the player upwards
                 * if the distance from the bottomost point of the collider to the hit position
                 * is less than the minimal distance. 
                 */

                Vector2 vec = rigid.velocity;
                vec.y = jumpPower;

                rigid.velocity = vec;
            }
        }
    }
}
