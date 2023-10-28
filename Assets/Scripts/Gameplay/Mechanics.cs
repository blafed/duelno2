using UnityEngine;
public static class Mechanics
{
    public static int CalculateDamage(int damage, float actualDistance, float radius, float maxDamageRadiusRatio)
    {
        var f = actualDistance / radius;
        if (f < maxDamageRadiusRatio)
        {
            return damage;
        }

        var damageRatio = 1 - (f - maxDamageRadiusRatio) / (1 - maxDamageRadiusRatio);

        return Mathf.Max(Mathf.RoundToInt(damage * damageRatio), 1);
    }
}