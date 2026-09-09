using TMPro;
using UnityEngine;

public class DamagableTest : MonoBehaviour, IDamage
{
    public float health = 1000;
    public TMP_Text text;

    public void AddEffect(WoundTypes type, BodyParts bodyPart)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        text.text = health.ToString();
    }
}
