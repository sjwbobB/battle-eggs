using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * GUI Elements struct
 * Contains all the GUI elements that need to be accessed
 */
[Serializable]
public struct GUIElements
{
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI armor;
}

/*
 * Keys struct 
 * Contains all the KeyCodes for player controls
 */
[Serializable]
public struct Keys
{
    public KeyCode jumpKey;

    public KeyCode debugGiveItemKey;
    public KeyCode debugSwitchToItem0Key;
}

/*
 * Movement struct
 * Contains information about player move speed, jump power, etc.
 */
[Serializable]
public struct Movement
{
    public float moveSpeed;
    public float jumpPower;

    public LayerMask groundLayerMask;
}

public class PlayerControl : MonoBehaviour
{
    public GUIElements guiElements;
    public Keys keybinds;
    public Movement movement;

    public EntityInfo entityInfo;
    public Rigidbody2D rigid;
    public new BoxCollider2D collider;
    public new SpriteRenderer renderer;

    private Vector2 worldMousePos;

    /*
     * BoxCasts under the player and returns true or false based on whether we hit ground
     * Ground is determined by groundLayerMask
     */
    private bool IsGrounded()
    {
        float testError = .05f;
        RaycastHit2D hit = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, testError, movement.groundLayerMask);
        Color rayColor;

        if (hit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        // Debug
        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + testError), rayColor);

        return hit.collider != null;
    }

    /*
     * Makes the player jump
     */
    private void Jump()
    {
        Vector2 vec = rigid.velocity;

        vec.y = movement.jumpPower;

        rigid.velocity = vec;
    }

    /*
     * Sets the held item to the item at slot indexInInventory of the inventory
     */
    private void ChangeItem(int indexInInventory)
    {
        entityInfo.currentEquipment.SetHeldItem(indexInInventory);
    }

    /*
     * Updates GUI elements
     */
    private void UpdateUIElements()
    {
        guiElements.weaponName.text = entityInfo.currentEquipment.heldItemObject.name; // Weapon name
        guiElements.armor.text = "Armor: " + entityInfo.currentEquipment.GetArmor().GetDurability(); // Armor durability
    }

    /*
     * Sets worldMousePos to the cursor position in world space
     * Sets the aiming position in EntityInfo to the same
     */
    void FixedUpdate()
    {
        worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        entityInfo.SetAimingAt(worldMousePos);
    }

    void Update()
    {
        UpdateUIElements();

        // Get player inputs
        float leftright = Input.GetAxisRaw("Horizontal");
        bool jumping = Input.GetKeyDown(keybinds.jumpKey);

        // Move player left and right, minding the gravity
        rigid.velocity = new Vector2(0.0f, rigid.velocity.y) + Vector2.right * leftright * movement.moveSpeed;

        // Flip player sprite to look at cursor
        renderer.flipX = worldMousePos.x > transform.position.x;

        if (jumping && IsGrounded())
        {
            // Make the player jump if the jump key was pressed and we're on the ground
            Jump();
        }

        // Debug stuff
        if (Input.GetKeyDown(keybinds.debugGiveItemKey))
        {
            // Test giving items
            entityInfo.currentEquipment.GiveItem(new EquipmentItem
            {
                name = "No one:"
            });
        }

        if (Input.GetKeyDown(keybinds.debugSwitchToItem0Key))
        {
            // Test changing held item
            ChangeItem(0);
        }

        Debug.DrawLine(transform.position, entityInfo.GetAimingAt());
    }
}
