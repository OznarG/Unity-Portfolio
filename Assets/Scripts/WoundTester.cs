using UnityEditor;
using UnityEngine;

public class WoundTester : MonoBehaviour
{
    //Wpund tester is what damages the player and add Wound on the player 
    public void OnTriggerEnter(Collider other)
    {
        //TODO: I have to add chances of bites and Scratch etc.
        //Takes the Interface of the object it collides with
        IDamage damageable = other.GetComponent<IDamage>();

        if(damageable != null )
        {
            //Randomly chooses a wound and a body part to affect
            WoundTypes type = (WoundTypes)Random.Range(0, System.Enum.GetValues(typeof(WoundTypes)).Length);
            BodyParts part = (BodyParts)Random.Range(0, System.Enum.GetValues(typeof(BodyParts)).Length);
            ////Debug informations 
            //Debug.Log("Random wound: " + type);
            //Debug.Log("Random body part: " + part);

            //Add the effect to the player or hitted object and then add damage
            damageable.AddEffect(type, part);
            damageable.TakeDamage(10);
        }
    }
}
