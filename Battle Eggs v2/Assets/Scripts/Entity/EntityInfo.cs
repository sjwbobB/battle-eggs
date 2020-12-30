using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class that contains info about entities
 */
public class EntityInfo : MonoBehaviour
{
    public EntityEquipment currentEquipment;

    private int health;
    private Vector2 aimingAt;

    public int GetHealth()
    {
        return health;
    }

    public void SetAimingAt(Vector2 newAim)
    {
        aimingAt = newAim;
    }

    public Vector2 GetAimingAt()
    {
        return aimingAt;
    }

    /*
     * Make the entity take this amount of damage
     */
    public int TakeDamage(int damage)
    {
        // Pass TakeDamage onto armor piece
        currentEquipment.GetArmor().TakeDamage(damage);

        // Calculate new health
        int newHealth = currentEquipment.GetArmor().Protect(health, damage);
        health = newHealth;

        return health - newHealth;
    }
}
