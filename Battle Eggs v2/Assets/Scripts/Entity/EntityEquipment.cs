using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Armor class
 * Represents armor with different durability and protection
 */
[Serializable]
public class Armor
{
    private int durability = 100, durabilityDiv = 0, protection;

    // Whether this armor needs some sort of activation (key press, mouse click, etc.)
    private bool needsActivation;

    private bool active = false;

    // Constant that represents armor with no protection or durability
    public static readonly Armor nullArmor = new Armor(0, 0, false);

    public Armor(int iDurDiv, int iProt, bool iNeedsActivation)
    {
        durabilityDiv = iDurDiv;
        protection = iProt;
        needsActivation = iNeedsActivation;
    }

    public int GetProtectionValue()
    {
        return protection;
    }

    public int GetDurability()
    {
        return durability;
    }

    public void SetActive(bool isActive)
    {
        active = isActive;
    }

    /*
     * Make the armor take this amount of damage
     */
    public void TakeDamage(int damage)
    {
        if (needsActivation && !active)
            return;

        int armorDmg = damage / (durabilityDiv + 1);
        durability -= armorDmg;
    }

    /*
     * Calculate what should health be after being protected by armor (if it's active)
     */
    public int Protect(int health, int damage)
    {
        if (active)
            return health - (damage / (protection + 1));
        else
            return health - damage;
    }
}

/*
 * Equipment Item struct
 * Represents items that can be equipped
 */
[Serializable]
public struct EquipmentItem
{
    public string name;
    public Sprite sprite;
}

public class EntityEquipment : MonoBehaviour
{
    private Armor armor = Armor.nullArmor; // Armor is nullArmor by default
    public GameObject heldItemObject;

    private readonly List<EquipmentItem> inventory = new List<EquipmentItem>();

    public void SetArmor(Armor newArmor)
    {
        armor = newArmor;
    }

    public Armor GetArmor()
    {
        return armor;
    }

    /*
     * Add item to entity's inventory
     */
    public void GiveItem(EquipmentItem givenItem)
    {
        inventory.Add(givenItem);
    }

    public List<EquipmentItem> GetInventory()
    {
        return inventory;
    }

    /*
     * Set entity's currently held item to be the item at this index in the inventory
     */
    public void SetHeldItem(int index)
    {
        heldItemObject.GetComponent<SpriteRenderer>().name = inventory[index].name;
        heldItemObject.GetComponent<SpriteRenderer>().sprite = inventory[index].sprite;
    }

    void Update()
    {
        // Point held item at aim position
        Vector2 aimPos = gameObject.GetComponent<EntityInfo>().GetAimingAt();
        SpriteRenderer renderer = heldItemObject.GetComponent<SpriteRenderer>();

        // Keep item sprite bottom side down
        renderer.flipY = aimPos.x < heldItemObject.transform.position.x;

        // Point item at the aim position
        heldItemObject.transform.right = aimPos - (Vector2) gameObject.transform.position;
    }
}
