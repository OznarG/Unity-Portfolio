using TMPro;
using UnityEngine;

//This gets damage from the player gun and put it on test to test it 
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
