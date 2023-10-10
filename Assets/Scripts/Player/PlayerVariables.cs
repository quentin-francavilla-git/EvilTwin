using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public const int maxHealth = 20;
    public static int currentHealth = maxHealth;
    public const int maxShield = 20;
    public static int currentShield = 0;
    [Space(5)]

    [Header("Combat Variables")]
    public static Vector3 levelPosition;

    public static void Heal(int heal) {
        int missingHealth = maxHealth - currentHealth;

        if (currentHealth + heal > maxHealth) {
            currentHealth = maxHealth;
            heal -= missingHealth;
            currentShield += heal;
            currentShield = (currentShield > maxShield) ? maxShield : currentShield;
            return;
        }

        currentHealth += heal;
    }

    public static void Damage(int damage)
    {
        if (currentShield > 0) {
            DamageShield(damage);
            return;
        }

        currentHealth -= damage;
    }

    static void DamageShield(int damage)
    {
        currentShield -= damage;
        if (currentShield < 0) {
            currentShield = 0;
        }
    }
}
