using UnityEngine;

public class EnemyHitSpots : MonoBehaviour, IDamage
{
    [SerializeField] Enemy enemy;
    [SerializeField] float damageMultiplier;

    public void TakeDamage(float amount)
    {
        switch(damageMultiplier)
        {
            case 0:
                enemy.TakeDamage(amount); break;
            case 1:
                amount = amount + (amount * 0.5f);
                enemy.TakeDamage(amount );Debug.Log(1.5); break;
                
            case 2:
                amount = amount * 2;
                enemy.TakeDamage(amount);  Debug.Log("x2"); break;
               
            default:
                break;
        }
    }

}
