using UnityEngine;

public class DamagableTest : MonoBehaviour, IDamage
{
    public float health = 100;

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
