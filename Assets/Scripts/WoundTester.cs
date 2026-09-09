using UnityEditor;
using UnityEngine;

public class WoundTester : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        IDamage damageable = other.GetComponent<IDamage>();

        if(damageable != null )
        {
            WoundTypes type = (WoundTypes)Random.Range(0, System.Enum.GetValues(typeof(WoundTypes)).Length);
            BodyParts part = (BodyParts)Random.Range(0, System.Enum.GetValues(typeof(BodyParts)).Length);
            Debug.Log("Random wound: " + type);
            Debug.Log("Random body part: " + part);

            damageable.AddEffect(type, part);
        }
    }
}
