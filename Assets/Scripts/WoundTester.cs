using UnityEngine;

public class WoundTester : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        IDamage damageable = other.GetComponent<IDamage>();

        if(damageable != null )
        {
            damageable.AddEffect();
        }
    }
}
