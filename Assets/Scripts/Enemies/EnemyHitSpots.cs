using UnityEngine;

public class EnemyHitSpots : MonoBehaviour, IDamage
{
    //This is added on the enemies body parts and based on the body part will be the damageMultiplier
    [SerializeField] Enemy enemy;
    [SerializeField] float damageMultiplier;

    //Not Need to implement because is used by the player
    public void AddEffect(WoundTypes type, BodyParts bodyPart)
    {
        throw new System.NotImplementedException();
    }
    //Take damage and  choose house much based on multiplier
    public void TakeDamage(float amount)
    {
        switch(damageMultiplier)
        {
            case 0:
                enemy.TakeDamage(amount); break;
            case 1:
                amount = amount + (amount * 0.5f);
                enemy.TakeDamage(amount ); break;
                
            case 2:
                amount = amount * 2;
                enemy.TakeDamage(amount); break;
               
            default:
                break;
        }
    }

}
